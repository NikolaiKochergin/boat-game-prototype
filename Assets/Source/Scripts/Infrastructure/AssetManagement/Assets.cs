using Reflex.Core;
using Reflex.Injectors;
using UnityEngine;

namespace Source.Scripts.Infrastructure.AssetManagement
{
    public class Assets : IAssets
    {
        private readonly Container _container;

        public Assets(Container container) => _container = container;

        public T Instantiate<T>(string path) where T : Object
        {
            T prefab = Resources.Load<T>(path);
            return Object.Instantiate(prefab);
        }
        
        public T Instantiate<T>(string path, Vector3 at, Quaternion rotation) where T : Object
        {
            T prefab = Resources.Load<T>(path);
            return Object.Instantiate(prefab, at, rotation);
        }

        public T Inject<T>(T prefab, Transform parent) where T : Component
        {
            //T prefab = Resources.Load<T>(path);
            
            T instance = Object.Instantiate(prefab, parent);

            foreach (MonoBehaviour injectable in instance.GetComponentsInChildren<MonoBehaviour>(true))
                AttributeInjector.Inject(injectable, _container);
            
            return instance;
        }
    }
}