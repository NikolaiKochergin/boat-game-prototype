using Source.Scripts.Services.Race;

namespace Source.Scripts.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IRaceService _raceService;

        public GameLoopState(GameStateMachine gameStateMachine, IRaceService raceService)
        {
            _gameStateMachine = gameStateMachine;
            _raceService = raceService;
        }
        
        public void Enter()
        {
            _raceService.RedShipWin += OnRedShipWin;
            _raceService.BlueShipWin += OnBlueShipWin;
        }

        public void Exit()
        {
        }

        private void OnRedShipWin()
        {
            Cleanup();
        }

        private void OnBlueShipWin()
        {
            Cleanup();
        }

        private void Cleanup()
        {
            _raceService.RedShipWin -= OnRedShipWin;
            _raceService.BlueShipWin -= OnBlueShipWin;
            _gameStateMachine.Enter<EndLevelState>();
        }
    }
}