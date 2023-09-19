using Cinemachine;
using Source.Scripts.Services.Factory;
using UnityEngine;

namespace Source.Scripts.Services.Camera
{
    public class CameraService : ICameraService
    {
        private readonly IGameFactory _gameFactory;

        public CameraService(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public void SetTrackPoint(Transform transform)
        {
            CinemachineVirtualCamera gameCamera = _gameFactory.CreateGameCamera();

            gameCamera.Follow = transform;
            gameCamera.LookAt = transform;
        }
    }
}