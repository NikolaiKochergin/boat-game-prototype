using UnityEngine;

namespace Source.Scripts.Infrastructure.AssetManagement
{
    public class Assets : IAssets
    {
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
    }
}