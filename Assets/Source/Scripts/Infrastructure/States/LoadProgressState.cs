namespace Source.Scripts.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public LoadProgressState(GameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        public void Enter()
        {
            _stateMachine.Enter<LoadLevelState, string>("GameScene");
        }

        public void Exit()
        {
        }
    }
}