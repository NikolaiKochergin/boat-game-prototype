using System.Collections.Generic;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;
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

        public void CleanUp()
        {
            _progressReaders.Clear();
            _progressWriters.Clear();
        }

        private T InstantiateRegistered<T>(string prefabPath) where T : Object, ISavedProgressReader
        {
            T gameObject = _assets.Instantiate<T>(prefabPath);
            Register(gameObject);

            return gameObject;
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                _progressWriters.Add(progressWriter);
            
            _progressReaders.Add(progressReader);
        }
    }
}