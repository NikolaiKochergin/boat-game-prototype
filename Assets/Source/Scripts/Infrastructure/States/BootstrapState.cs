using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Services;
using Source.Scripts.Services.Camera;
using Source.Scripts.Services.Factory;
using Source.Scripts.Services.Input;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.Race;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.Services.StaticData;

namespace Source.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter() => 
            _sceneLoader?.Load("LoadingScene", onLoaded: EnterLoadLevel);

        public void Exit()
        {
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            RegisterStaticDataService();
            
            _services.RegisterSingle<IInputService>(InputService());
            _services.RegisterSingle<IAssets>(new Assets());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            
            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IAssets>(),
                _services.Single<IStaticDataService>()));
            
            _services.RegisterSingle<ICameraService>(new CameraService(
                _services.Single<IGameFactory>()));
            
            _services.RegisterSingle<IRaceService>(new RaceService(
                _services.Single<IGameFactory>(),
                _services.Single<IInputService>(),
                _services.Single<ICameraService>()));
            
            _services.RegisterSingle<ISaveLoadService>(SaveLoadService());
        }

        private void RegisterStaticDataService()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }

        private static IInputService InputService() => 
            new InputService();

        private ISaveLoadService SaveLoadService() =>
            new PrefsSaveLoadService(
                _services.Single<IPersistentProgressService>(),
                _services.Single<IGameFactory>());
    }
}