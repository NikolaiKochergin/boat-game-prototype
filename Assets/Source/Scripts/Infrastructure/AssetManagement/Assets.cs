using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Source.Scripts.Infrastructure.AssetManagement
{
    public class Assets : IAssets
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completeCache =
            new Dictionary<string, AsyncOperationHandle>();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles =
            new Dictionary<string, List<AsyncOperationHandle>>();

        public void Initialize() => Addressables.InitializeAsync();
        
        public async UniTask<TObject> Load<TObject>(AssetReference assetReference) where TObject : class
        {
            if (_completeCache.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completeHandle))
                return completeHandle.Result as TObject;

            return await RunWithCacheOnComplete(
                cacheKey: assetReference.AssetGUID,
                Addressables.LoadAssetAsync<TObject>(assetReference));
        }
        
        public async UniTask<TObject> Load<TObject>(string address) where TObject : class
        {
            if (_completeCache.TryGetValue(address, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as TObject;

            return await RunWithCacheOnComplete(
                cacheKey: address,
                Addressables.LoadAssetAsync<TObject>(address));
        }

        public async UniTask<TComponent> Load<TObject, TComponent>(AssetReference assetReference) where TObject : Object where TComponent : Component
        {
            GameObject go = await Load<TObject>(assetReference) as GameObject;
            if (go == null)
                throw new NullReferenceException($"Addressables doesn't contain key: {assetReference}");
            
            if (go.TryGetComponent(out TComponent component) == false)
                throw new NullReferenceException(
                    $"Object of type {typeof(TComponent)} is null on attempt to load it form addressables");
            
            return component;
        }
        
        public async UniTask<TComponent> Load<TObject, TComponent>(string address) where TObject : Object where TComponent : Component
        {
            GameObject go = await Load<TObject>(address) as GameObject;
            if (go == null)
                throw new NullReferenceException($"Addressables doesn't contain key: {address}");
            
            if (go.TryGetComponent(out TComponent component) == false)
                throw new NullReferenceException(
                    $"Object of type {typeof(TComponent)} is null on attempt to load it form addressables");
            
            return component;
        }
        
        public void Cleanup()
        {
            foreach (List<AsyncOperationHandle> resourceHandles in _handles.Values)
            foreach (AsyncOperationHandle handle in resourceHandles)
                Addressables.Release(handle);
            
            _completeCache.Clear();
            _handles.Clear();
        }

        private async UniTask<T> RunWithCacheOnComplete<T>(string cacheKey, AsyncOperationHandle<T> handle)
            where T : class
        {
            handle.Completed += completeHandle => _completeCache[cacheKey] = completeHandle;
            AddHandle(cacheKey, handle);
            return await handle.ToUniTask();
        }

        private void AddHandle<T>(string key, AsyncOperationHandle<T> handle) where T : class
        {
            if (!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandles))
            {
                resourceHandles = new List<AsyncOperationHandle>();
                _handles[key] = resourceHandles;
            }
            resourceHandles.Add(handle);
        }
    }
}