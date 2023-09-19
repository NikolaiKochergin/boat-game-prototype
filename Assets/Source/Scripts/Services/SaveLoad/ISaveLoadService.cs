using System;
using Source.Scripts.Data;

namespace Source.Scripts.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress(Action onSuccessCallback = null);
        void LoadProgress(Action<PlayerProgress> onSuccessCallback);
    }
}