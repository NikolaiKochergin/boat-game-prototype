using Source.Scripts.Services.Race;
using Source.Scripts.UI.Services;

namespace Source.Scripts.Infrastructure.States
{
    public class RaceProgressState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IWindowService _windows;
        private readonly IRaceService _raceService;

        public RaceProgressState(
            IGameStateMachine gameStateMachine,
            IWindowService windows,
            IRaceService raceService)
        {
            _gameStateMachine = gameStateMachine;
            _windows = windows;
            _raceService = raceService;
        }
        
        public void Enter()
        {
            _raceService.StartRace();
            _raceService.RedShipWin += OnRedShipWin;
            _raceService.BlueShipWin += OnBlueShipWin;
            _windows.OpenWindow(WindowId.RaceProgress);
        }

        public void Exit()
        {
            _windows.CloseWindow(WindowId.RaceProgress);
        }

        private void OnRedShipWin() => 
            Cleanup();

        private void OnBlueShipWin() => 
            Cleanup();

        private void Cleanup()
        {
            _raceService.RedShipWin -= OnRedShipWin;
            _raceService.BlueShipWin -= OnBlueShipWin;
            _gameStateMachine.Enter<RaceOverState>();
        }
    }
}