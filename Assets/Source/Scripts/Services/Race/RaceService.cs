using System;
using Source.Scripts.Extensions;
using Source.Scripts.Logic;
using Source.Scripts.Player;
using Source.Scripts.Services.Camera;
using Source.Scripts.Services.Factory;
using Source.Scripts.Services.Input;
using UnityEngine;

namespace Source.Scripts.Services.Race
{
    public class RaceService : IRaceService
    {
        private readonly IGameFactory _factory;
        private readonly IInputService _input;
        private readonly ICameraService _cameraService;

        private Ship _redShip;
        private Ship _blueShip;
        private Finish _finishLine;
        private TrackPoint _trackPoint;

        public RaceService(IGameFactory factory, IInputService input, ICameraService cameraService)
        {
            _factory = factory;
            _input = input;
            _cameraService = cameraService;
        }

        public float RedShipPosition => GetShipPosition(_redShip.transform);
        public float BlueShipPosition => GetShipPosition(_blueShip.transform);

        public event Action RedShipWin;
        public event Action BlueShipWin;

        public void PrepareToRace()
        {
            _redShip = _factory.CreateRedShip();
            _blueShip = _factory.CreateBlueShip();

            _redShip.TriggerObserver.TriggerEnter += OnRedShipWin;
            _blueShip.TriggerObserver.TriggerEnter += OnBlueShipWin;
            
            _input.Initialize( _redShip.Input, _blueShip.Input);

            _redShip.transform.position = new Vector3(-3.5f, 0, 0);
            _blueShip.transform.position = new Vector3(3.5f, 0, 0);

            _trackPoint = _factory.CreateTrackPoint();
            _trackPoint.StartTrack(_redShip.transform, _blueShip.transform);
            _cameraService.SetTrackPoint(_trackPoint.transform);

            _finishLine = _factory.CreateFinishLine();
            _finishLine.transform.position = new Vector3(0, 0, 100);
            
            _input.EnableMenuInput();
        }

        private void OnRedShipWin(Collider collider)
        {
            if (collider.TryGetComponent(out Finish finish))
            {
                StopRace();
                RedShipWin?.Invoke();
            }
        }

        private void OnBlueShipWin(Collider collider)
        {
            if (collider.TryGetComponent(out Finish finish))
            {
                StopRace();
                BlueShipWin?.Invoke();
            }
        }

        public void StartRace()
        {
            _input.DisableMenuInput();
            _input.EnablePlayerInput();
        }

        public void Cleanup()
        {
            _trackPoint?.Destroy();
            _redShip?.Destroy();
            _blueShip?.Destroy();
            _finishLine?.Destroy();
        }

        private void StopRace()
        {
            _redShip.TriggerObserver.TriggerEnter -= OnRedShipWin;
            _blueShip.TriggerObserver.TriggerEnter -= OnBlueShipWin;
            
            _input.DisablePlayersInput();
            
            _redShip.Mover.SetFinishPositionZ(_finishLine.transform.position.z);
            _blueShip.Mover.SetFinishPositionZ(_finishLine.transform.position.z);
        }

        private float GetShipPosition(Transform shipTransform) => 
            Mathf.Clamp(shipTransform.position.z / _finishLine.transform.position.z, 0, 1);
    }
}