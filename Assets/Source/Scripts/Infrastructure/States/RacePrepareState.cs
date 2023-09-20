using Source.Scripts.UI.Services;

namespace Source.Scripts.Infrastructure.States
{
    public class RacePrepareState : IState
    {
        private readonly IWindowService _windows;

        public RacePrepareState(IWindowService windows)
        {
            _windows = windows;
        }
        
        public void Enter()
        {
            _windows.OpenWindow(WindowId.RacePrepare);
        }

        public void Exit()
        {
            _windows.CloseWindow(WindowId.RacePrepare);
        }
    }
}