using Source.Scripts.Logic;
using Source.Scripts.Services.Race;

namespace Source.Scripts.Services.Input
{
    public class InputService : IInputService
    {
        private readonly InputActions _inputActions;
        
        private PlayerInput _leftPlayer;
        private PlayerInput _rightPlayer;
        private IRaceService _raceService;

        public InputService()
        {
            _inputActions = new InputActions();
            _inputActions.PlayerLeft.MoveLeft.performed += ctx => OnPlayerLeftMove();
            _inputActions.PlayerLeft.MoveRight.performed += ctx => OnPlayerLeftMove();

            _inputActions.PlayerRight.MoveLeft.performed += ctx => OnPlayerRightMove();
            _inputActions.PlayerRight.MoveRight.performed += ctx => OnPlayerRightMove();

            _inputActions.Menu.StartRace.performed += ctx => OnStartRace();
        }

        public void Initialize(IRaceService raceService, PlayerInput leftPlayer, PlayerInput rightPlayer)
        {
            _raceService = raceService;
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
            _raceService.StartRace();
        }
    }
}