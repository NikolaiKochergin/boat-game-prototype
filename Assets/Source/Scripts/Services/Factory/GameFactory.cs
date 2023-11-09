using System.Collections.Generic;
using Cinemachine;
using Cysharp.Threading.Tasks;
using Reflex.Core;
using Reflex.Injectors;
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
        private readonly Container _container;

        public IEnumerable<ISavedProgressReader> ProgressReaders => _progressReaders;

        public IEnumerable<ISavedProgress> ProgressWriters => _progressWriters;

        public GameFactory(IAssets assets,
            IStaticDataService staticData,
            Container container)
        {
            _assets = assets;
            _staticData = staticData;
            _container = container;
        }

        public void WarmUp()
        {
            _assets.Load<GameObject>(AssetAddress.ShipRed);
            _assets.Load<GameObject>(AssetAddress.ShipBlue);
        }

        public async UniTask<Ship> CreateRedShip() => 
            await InstantiateRegistered<Ship>(AssetAddress.ShipRed);

        public async UniTask<Ship> CreateBlueShip() => 
            await InstantiateRegistered<Ship>(AssetAddress.ShipBlue);

        public async UniTask<CinemachineVirtualCamera> CreateGameCamera() => 
            await InstantiateAndInject<CinemachineVirtualCamera>(AssetAddress.GameCamera);

        public async UniTask<TrackPoint> CreateTrackPoint() => 
            await InstantiateAndInject<TrackPoint>(AssetAddress.TrackPoint);

        public async UniTask<Finish> CreateFinishLine() => 
            await InstantiateAndInject<Finish>(AssetAddress.FinishLine);

        public void Cleanup()
        {
            _progressReaders.Clear();
            _progressWriters.Clear();
        }

        private async UniTask<T> InstantiateRegistered<T>(string address) where T : Component, ISavedProgressReader
        {
            T newObject = await InstantiateAndInject<T>(address);
            Register(newObject);

            return newObject;
        }

        private async UniTask<T> InstantiateAndInject<T>(string address) where T : Component
        {
            T prefab = await _assets.Load<GameObject, T>(address);
            T newObject = Object.Instantiate(prefab);
            AttributeInjector.Inject(newObject, _container);
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