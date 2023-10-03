using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.Scripts.Infrastructure.AssetManagement
{
    public class Assets : IAssets
    {
        private readonly IObjectResolver _resolver;

        public Assets(IObjectResolver resolver) => 
            _resolver = resolver;

        public T Instantiate<T>(string path) where T : Object
        {
            T prefab = Resources.Load<T>(path);
            return _resolver.Instantiate(prefab);
        }
        
        public T Instantiate<T>(string path, Vector3 at, Quaternion rotation) where T : Object
        {
            T prefab = Resources.Load<T>(path);
            return _resolver.Instantiate(prefab, at, rotation);
        }

        public T Instantiate<T>(string path, Transform parent) where T : Object
        {
            T prefab = Resources.Load<T>(path);
            return _resolver.Instantiate(prefab, parent);
        }
    }
}