using System;
using Reflex.Core;
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
using UnityEngine;

namespace Source.Scripts.ReflexTesting
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public static Container Container { get; private set; }
        
        public void InstallBindings(ContainerDescriptor descriptor)
        { 
            descriptor
                .AddSingleton(typeof(SceneLoader))
                .AddSingleton(typeof(StaticDataService), typeof(IStaticDataService))
                .AddSingleton(typeof(InputService), typeof(IInputService))
                .AddSingleton(typeof(Assets), typeof(IAssets))
                .AddSingleton(typeof(PersistentProgressService), typeof(IPersistentProgressService))
                .AddSingleton(typeof(GameFactory), typeof(IGameFactory))
                .AddSingleton(typeof(CameraService), typeof(ICameraService))
                .AddSingleton(typeof(UIFactory), typeof(IUIFactory))
                .AddSingleton(typeof(WindowService), typeof(IWindowService))
                .AddSingleton(typeof(RaceService), typeof(IRaceService))
                .AddSingleton(typeof(PrefsSaveLoadService), typeof(ISaveLoadService));

            descriptor.OnContainerBuilt += OnProjectContainerBuilt;
        }

        private void OnProjectContainerBuilt(Container container)
        {
            Container = container;
        }
    }
}