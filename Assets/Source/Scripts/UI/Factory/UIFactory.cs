using Cysharp.Threading.Tasks;
using Reflex.Core;
using Reflex.Injectors;
using Source.Scripts.Extensions;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Services.StaticData;
using Source.Scripts.UI.Elements;
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
            UIRoot uiRootObj = await _assets.Load<GameObject, UIRoot>(UIRootAddress);
            _uiRoot = Object.Instantiate(uiRootObj).transform;
        }

        public async UniTask<WindowBase> CreateWindow(WindowId id)
        {
            WindowBase prefab = await _assets.Load<GameObject, WindowBase>(_staticData.ForWindow(id).Address);
            return InstantiateAndInject(prefab, _uiRoot);
        }

        public void Cleanup()
        {
            _uiRoot?.Destroy();
            _uiRoot = null;
        }
        
        private T InstantiateAndInject<T>(T prefab, Transform parent = null) where T : Component
        {
            T instance = Object.Instantiate(prefab, parent);

            foreach (MonoBehaviour injectable in instance.GetComponentsInChildren<MonoBehaviour>(true))
                AttributeInjector.Inject(injectable, _container);
            
            return instance;
        }
    }
}