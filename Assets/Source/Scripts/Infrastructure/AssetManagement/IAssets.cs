using Source.Scripts.Services;
using UnityEngine;

namespace Source.Scripts.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        T Instantiate<T>(string path) where T : Object;
        T Instantiate<T>(string path, Vector3 at, Quaternion rotation) where T : Object;
        T Instantiate<T>(string path, Transform parent) where T : Object;
    }
}