using Reflex.Core;
using Source.Scripts.Infrastructure.States;
using UnityEngine;

namespace Source.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour , IInstaller
    {
        private Game _game;

        public void InstallBindings(ContainerDescriptor descriptor)
        {
            descriptor.OnContainerBuilt += container =>
            {
                _game = container.Construct<Game>();
                _game.StateMachine.Enter<BootstrapState>();
                DontDestroyOnLoad(this);
            };
        }
    }
}