using Cysharp.Threading.Tasks;
using Reflex.Core;
using Reflex.Injectors;
using Source.Scripts.Extensions;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Services.StaticData;
using Source.Scripts.UI.Services;
using Source.Scripts.UI.Windows;
using UnityEngine;

namespace Source.Scripts.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootAddress = "UIRoot";
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;
        private readonly Container _container;

        private Transform _uiRoot;

        public UIFactory(IAssets assets, IStaticDataService staticData, Container container)
        {
            _assets = assets;
            _staticData = staticData;
            _container = container;
        }

        public async UniTaskVoid WarmUp() => 
            await _assets.Load<GameObject>(UIRootAddress);

        public async UniTask CreateUIRoot()
        {
            GameObject uiRootPrefab = await _assets.Load<GameObject>(UIRootAddress);
            _uiRoot = Object.Instantiate(uiRootPrefab).transform;
        }

        public WindowBase CreateWindow(WindowId id) => 
            InstantiateAndInject(_staticData.ForWindow(id).Prefab, _uiRoot);

        public void Cleanup()
        {
            _uiRoot?.Destroy();
            _uiRoot = null;
        }
        
        private T InstantiateAndInject<T>(T prefab, Transform parent) where T : Component
        {
            T instance = Object.Instantiate(prefab, parent);

            foreach (MonoBehaviour injectable in instance.GetComponentsInChildren<MonoBehaviour>(true))
                AttributeInjector.Inject(injectable, _container);
            
            return instance;
        }
    }
}