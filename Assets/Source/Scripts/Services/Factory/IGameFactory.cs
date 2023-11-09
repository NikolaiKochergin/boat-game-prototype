using System.Collections.Generic;
using Cinemachine;
using Cysharp.Threading.Tasks;
using Source.Scripts.Logic;
using Source.Scripts.Player;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Services.Factory
{
    public interface IGameFactory : IService
    {
        IEnumerable<ISavedProgressReader> ProgressReaders { get; }
        IEnumerable<ISavedProgress> ProgressWriters { get; }
        UniTask<Ship> CreateRedShip();
        UniTask<Ship> CreateBlueShip();
        void Cleanup();
        UniTask<CinemachineVirtualCamera> CreateGameCamera();
        UniTask<TrackPoint> CreateTrackPoint();
        UniTask<Finish> CreateFinishLine();
        void WarmUp();
    }
}