using Reflex.Core;
using Source.Scripts.Services.StaticData;

namespace Source.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly Container _container;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, Container container)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _container = container;

            LoadStaticData();
        }

        public void Enter() => 
            _sceneLoader.Load("LoadingScene", EnterLoadLevel);

        public void Exit()
        {
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadProgressState>();

        private void LoadStaticData() => 
            _container.Resolve<IStaticDataService>().Load();
    }
}