using Source.Scripts.Services.StaticData;
using VContainer;

namespace Source.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IObjectResolver _resolver;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, IObjectResolver resolver)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _resolver = resolver;

            InitStaticDataService();
        }

        public void Enter() => 
            _sceneLoader?.Load("LoadingScene", onLoaded: EnterLoadLevel);

        public void Exit()
        {
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadProgressState>();

        private void InitStaticDataService()
        {
            _resolver.Resolve<IStaticDataService>().Load();
        }
    }
}