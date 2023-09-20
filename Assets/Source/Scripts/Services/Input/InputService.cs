using Source.Scripts.Infrastructure.States;
using Source.Scripts.Logic;
using UnityEngine;

namespace Source.Scripts.Services.Input
{
    public class InputService : IInputService
    {
        private readonly InputActions _inputActions;
        private readonly GameStateMachine _gameStateMachine;
        
        private PlayerInput _leftPlayer;
        private PlayerInput _rightPlayer;

        public InputService(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _inputActions = new InputActions();
            _inputActions.PlayerLeft.MoveLeft.performed += ctx => OnPlayerLeftMove();
            _inputActions.PlayerLeft.MoveRight.performed += ctx => OnPlayerLeftMove();

            _inputActions.PlayerRight.MoveLeft.performed += ctx => OnPlayerRightMove();
            _inputActions.PlayerRight.MoveRight.performed += ctx => OnPlayerRightMove();

            _inputActions.Menu.StartRace.performed += ctx => OnStartRace();
        }

        public void Initialize(PlayerInput leftPlayer, PlayerInput rightPlayer)
        {
            _leftPlayer = leftPlayer;
            _rightPlayer = rightPlayer;
        }

        public void EnablePlayerInput()
        {
            _inputActions.PlayerLeft.Enable();
            _inputActions.PlayerRight.Enable();
        }

        public void DisablePlayersInput()
        {
            _inputActions.PlayerLeft.Disable();
            _inputActions.PlayerRight.Disable();
        }

        public void EnableMenuInput() => 
            _inputActions.Menu.Enable();

        public void DisableMenuInput() => 
            _inputActions.Menu.Disable();

        private void OnPlayerLeftMove() => 
            _leftPlayer.AddMovePower();

        private void OnPlayerRightMove() => 
            _rightPlayer.AddMovePower();

        private void OnStartRace()
        {
            _inputActions.Menu.Disable();
            _gameStateMachine.Enter<RaceProgressState>();
        }
    }
}