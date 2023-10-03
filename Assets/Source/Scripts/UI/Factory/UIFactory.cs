using Source.Scripts.Extensions;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Services.StaticData;
using Source.Scripts.UI.Services;
using Source.Scripts.UI.StaticData;
using Source.Scripts.UI.Windows;
using UnityEngine;

namespace Source.Scripts.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;

        private Transform _uiRoot;

        public UIFactory(IAssets assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public void CreateUIRoot()
        {
            _uiRoot = _assets.Instantiate<Transform>(UIRootPath);
            _uiRoot.SetParent(null);
        }

        public WindowBase CreateMainMenuWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.SettingsMenu);
            return _assets.Instantiate<SettingsWindow>(config.PrefabPath, _uiRoot);
        }

        public WindowBase CreateRacePrepareWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.RacePrepare);
            return _assets.Instantiate<RacePrepareWindow>(config.PrefabPath, _uiRoot);
        }

        public WindowBase CreateRaceProgressWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.RaceProgress);
            return _assets.Instantiate<RaceProgressWindow>(config.PrefabPath, _uiRoot);
        }

        public WindowBase CreateRaceOverWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.RaceOver);
            return _assets.Instantiate<RaceOverWindow>(config.PrefabPath, _uiRoot);
        }

        public void Cleanup()
        {
            _uiRoot?.Destroy();
            _uiRoot = null;
        }
    }
}