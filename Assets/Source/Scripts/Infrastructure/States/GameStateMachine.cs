using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Source.Scripts.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly IObjectResolver _resolver;
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(IObjectResolver resolver) => 
            _resolver = resolver;

        public void RegisterStates()
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = _resolver.Resolve<BootstrapState>(),
                [typeof(LoadProgressState)] = _resolver.Resolve<LoadProgressState>(),
                [typeof(LoadLevelState)] = _resolver.Resolve<LoadLevelState>(),
                [typeof(RacePrepareState)] = _resolver.Resolve<RacePrepareState>(),
                [typeof(RaceProgressState)] = _resolver.Resolve<RaceProgressState>(),
                [typeof(RaceOverState)] = _resolver.Resolve<RaceOverState>(),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            if (_states.TryGetValue(typeof(TState), out IExitableState state) && state is TState typedState)
                return typedState;

            throw new ArgumentException(
                $"State of type {typeof(TState)} not found or does not implement IExitableState.");
        }
    }
}