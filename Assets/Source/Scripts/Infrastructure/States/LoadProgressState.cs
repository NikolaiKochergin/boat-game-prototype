﻿using System;
using Source.Scripts.Data;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoad;

        public LoadProgressState(
            GameStateMachine stateMachine,
            IPersistentProgressService progressService,
            ISaveLoadService saveLoad)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoad = saveLoad;
        }

        public void Enter()
        {
            Debug.Log("check loadprogress");
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