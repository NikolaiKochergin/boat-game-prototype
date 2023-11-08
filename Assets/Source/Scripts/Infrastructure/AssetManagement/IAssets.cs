using Cysharp.Threading.Tasks;
using Source.Scripts.Services;
using UnityEngine.AddressableAssets;

namespace Source.Scripts.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        UniTask<T> Load<T>(AssetReference assetReference) where T : class;
        UniTask<T> Load<T>(string address) where T : class;
        void Cleanup();
        void Initialize();
    }
}