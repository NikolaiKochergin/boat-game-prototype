using Reflex.Core;
using Source.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Source.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Start()
        {
            Addressables.LoadSceneAsync("LoadingScene", activateOnLoad: false).Completed += handle =>
            {
                ReflexSceneManager.PreInstallScene(handle.Result.Scene, descriptor => descriptor.OnContainerBuilt += OnContainerBuilt);
                handle.Result.ActivateAsync();
                DontDestroyOnLoad(this);
            };
        }

        private void OnContainerBuilt(Container container)
        {
            _game = container.Construct<Game>();
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}