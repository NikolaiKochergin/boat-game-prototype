using Reflex.Core;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Services.StaticData;

namespace Source.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly Container _container;

        public BootstrapState(IGameStateMachine stateMachine, Container container)
        {
            _stateMachine = stateMachine;
            _container = container;

            LoadStaticData();
            InitializeAssets();
        }

        public void Enter() => EnterLoadLevel();

        public void Exit() { }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadProgressState>();

        private void LoadStaticData() => 
            _container.Resolve<IStaticDataService>().Load();

        private void InitializeAssets() => 
            _container.Resolve<IAssets>().Initialize();
    }
}