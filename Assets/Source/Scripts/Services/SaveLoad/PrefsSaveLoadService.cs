using System;
using Source.Scripts.Data;
using Source.Scripts.Services.Factory;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.Services.SaveLoad
{
    public class PrefsSaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "ImmortalKombatMerge";
        
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public PrefsSaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress(Action onSuccessCallback = null)
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);
            
            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson().ToEncrypt());
        }

        public void LoadProgress(Action<PlayerProgress> onSuccessCallback) =>
            onSuccessCallback.Invoke(PlayerPrefs.GetString(ProgressKey)?.ToDecrypt().ToDeserialized<PlayerProgress>());
    }
}