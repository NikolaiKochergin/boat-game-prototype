using System.Collections.Generic;
using Cinemachine;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Logic;
using Source.Scripts.Player;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Source.Scripts.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly List<ISavedProgressReader> _progressReaders = new List<ISavedProgressReader>();
        private readonly List<ISavedProgress> _progressWriters = new List<ISavedProgress>();
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;
        
        public IEnumerable<ISavedProgressReader> ProgressReaders => _progressReaders;
        public IEnumerable<ISavedProgress> ProgressWriters => _progressWriters;

        public GameFactory(IAssets assets,
            IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public Ship CreateRedShip() => 
            InstantiateRegistered<Ship>(AssetPath.ShipRed);

        public Ship CreateBlueShip() => 
            InstantiateRegistered<Ship>(AssetPath.ShipBlue);

        public CinemachineVirtualCamera CreateGameCamera()
        {
            CinemachineVirtualCamera prefab = Resources.Load<CinemachineVirtualCamera>(AssetPath.GameCamera);
            return Object.Instantiate(prefab);
        }

        public TrackPoint CreateTrackPoint()
        {
            TrackPoint prefab = Resources.Load<TrackPoint>(AssetPath.TrackPoint);
            return Object.Instantiate(prefab);
        }

        public Finish CreateFinishLine()
        {
            Finish prefab = Resources.Load<Finish>(AssetPath.FinishLine);
            return Object.Instantiate(prefab);
        }

        public void Cleanup()
        {
            _progressReaders.Clear();
            _progressWriters.Clear();
        }

        private T InstantiateRegistered<T>(string prefabPath) where T : Object, ISavedProgressReader
        {
            T prefab = Resources.Load<T>(prefabPath);
            T newObject = Object.Instantiate(prefab);
            Register(newObject);

            return newObject;
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                _progressWriters.Add(progressWriter);
            
            _progressReaders.Add(progressReader);
        }
    }
}