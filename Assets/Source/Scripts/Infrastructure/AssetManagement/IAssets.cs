using Cysharp.Threading.Tasks;
using Source.Scripts.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Source.Scripts.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        void Initialize();
        UniTask<TObject> Load<TObject>(AssetReference assetReference) where TObject : class;
        UniTask<TObject> Load<TObject>(string address) where TObject : class;
        UniTask<TComponent> Load<TObject, TComponent>(AssetReference assetReference) where TObject : Object where TComponent : Component;
        UniTask<TComponent> Load<TObject, TComponent>(string address) where TObject : Object where TComponent : Component;
        void Cleanup();
    }
}