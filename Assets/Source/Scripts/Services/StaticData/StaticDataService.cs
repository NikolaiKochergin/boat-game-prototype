using Source.Scripts.StaticData;
using UnityEngine;

namespace Source.Scripts.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string GameConfigDataPath = "StaticData/GameConfig";

        private GameConfig _gameConfig;

        public void Load()
        {
            _gameConfig = Resources.Load<GameConfig>(GameConfigDataPath);
        }
    }
}