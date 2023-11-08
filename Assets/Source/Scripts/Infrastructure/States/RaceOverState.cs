using System.Collections;
using Source.Scripts.UI.Services;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States
{
    public class RaceOverState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IWindowService _windows;

        public RaceOverState(IGameStateMachine stateMachine, IWindowService windows)
        {
            _stateMachine = stateMachine;
            _windows = windows;
        }
        
        public void Enter()
        {
            _windows.OpenWindow(WindowId.RaceOver);
            Coroutines.StartRoutine(DelayBeforeRestartRoutine());
        }

        public void Exit()
        {
            _windows.CloseWindow(WindowId.RaceOver);
        }

        private IEnumerator DelayBeforeRestartRoutine()
        {
            yield return new WaitForSeconds(5f);
            _stateMachine.Enter<LoadLevelState, string>("GameScene");
        }
    }
}