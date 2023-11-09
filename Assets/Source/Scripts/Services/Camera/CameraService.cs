using Cinemachine;
using Cysharp.Threading.Tasks;
using Source.Scripts.Services.Factory;
using UnityEngine;

namespace Source.Scripts.Services.Camera
{
    public class CameraService : ICameraService
    {
        private readonly IGameFactory _gameFactory;

        public CameraService(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public async UniTaskVoid SetTrackPoint(Transform transform)
        {
            CinemachineVirtualCamera gameCamera = await _gameFactory.CreateGameCamera();

            gameCamera.Follow = transform;
            gameCamera.LookAt = transform;
        }
    }
}