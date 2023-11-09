using Reflex.Core;
using Source.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Start()
        {
            Addressables.LoadSceneAsync(SceneManager.GetSceneByBuildIndex(0).name, activateOnLoad: false).Completed += handle =>
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