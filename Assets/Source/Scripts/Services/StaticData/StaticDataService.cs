using System.Collections.Generic;
using System.Linq;
using Source.Scripts.StaticData;
using Source.Scripts.UI.Services;
using Source.Scripts.UI.StaticData;
using UnityEngine;

namespace Source.Scripts.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string GameConfigDataPath = "StaticData/GameConfig";
        private const string UIConfigDataPath = "UI/UIConfig";

        private GameConfig _gameConfig;
        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void Load()
        {
            _gameConfig = Resources
                .Load<GameConfig>(GameConfigDataPath);

            _windowConfigs = Resources
                .Load<UIConfig>(UIConfigDataPath)
                .WindowConfigs
                .ToDictionary(x => x.WindowId, x => x);
        }

        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out WindowConfig config)
                ? config
                : null;

        public GameConfig ForGameSettings() => 
            _gameConfig;
    }
}