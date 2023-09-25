using Source.Scripts.Infrastructure;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services.Camera;
using Source.Scripts.Services.Factory;
using Source.Scripts.Services.Input;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.Race;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.Services.StaticData;
using Source.Scripts.UI.Factory;
using Source.Scripts.UI.Services;
using VContainer;
using VContainer.Unity;

namespace Source.Scripts.Services
{
    public class VServices : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneLoader>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
            
            builder.Register<IStaticDataService, StaticDataService>(Lifetime.Singleton);
            builder.Register<IInputService, InputService>(Lifetime.Singleton);
            builder.Register<IAssets, Assets>(Lifetime.Singleton);
            builder.Register<IPersistentProgressService, PersistentProgressService>(Lifetime.Singleton);
            builder.Register<IGameFactory, GameFactory>(Lifetime.Singleton);
            builder.Register<ICameraService, CameraService>(Lifetime.Singleton);
            builder.Register<IUIFactory, UIFactory>(Lifetime.Singleton);
            builder.Register<IWindowService, WindowService>(Lifetime.Singleton);
            builder.Register<IRaceService, RaceService>(Lifetime.Singleton);
            builder.Register<ISaveLoadService, PrefsSaveLoadService>(Lifetime.Singleton);

            builder.Register<BootstrapState>(Lifetime.Singleton);
            builder.Register<LoadProgressState>(Lifetime.Singleton);
            builder.Register<LoadLevelState>(Lifetime.Singleton);
            builder.Register<RacePrepareState>(Lifetime.Singleton);
            builder.Register<RaceProgressState>(Lifetime.Singleton);
            builder.Register<RaceOverState>(Lifetime.Singleton);
        }
    }
}
