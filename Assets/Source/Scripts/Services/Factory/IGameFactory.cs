using System.Collections.Generic;
using Cinemachine;
using Source.Scripts.Logic;
using Source.Scripts.Player;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Services.Factory
{
    public interface IGameFactory : IService
    {
        IEnumerable<ISavedProgressReader> ProgressReaders { get; }
        IEnumerable<ISavedProgress> ProgressWriters { get; }
        Ship CreateRedShip();
        Ship CreateBlueShip();
        void CleanUp();
        CinemachineVirtualCamera CreateGameCamera();
        TrackPoint CreateTrackPoint();
        Finish CreateFinishLine();
    }
}