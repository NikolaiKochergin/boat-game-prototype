using System;
using Source.Scripts.Data;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;

namespace Source.Scripts.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoad;

        public LoadProgressState(
            IGameStateMachine stateMachine,
            IPersistentProgressService progressService,
            ISaveLoadService saveLoad)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoad = saveLoad;
        }

        public void Enter()
        {
            LoadProgressOrInitNew(() =>
            {
                _stateMachine.Enter<LoadLevelState, string>("GameScene");
            });
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew(Action onInitializedCallback)
        {
            _saveLoad.LoadProgress(progress =>
            {
                _progressService.Progress = progress ?? new PlayerProgress();
                onInitializedCallback?.Invoke();
            });
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress();
        }
    }
}