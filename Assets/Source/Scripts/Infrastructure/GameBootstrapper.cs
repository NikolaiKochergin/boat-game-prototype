using Reflex.Core;
using Source.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Start()
        {
            DontDestroyOnLoad(this);
            Scene loadScene = SceneManager.LoadScene("LoadingScene", new LoadSceneParameters(LoadSceneMode.Single));
            ReflexSceneManager.PreInstallScene(loadScene,
                descriptor => descriptor.OnContainerBuilt += container =>
                {
                    _game = container.Construct<Game>();
                    _game.StateMachine.Enter<BootstrapState>();
                });
        }
    }
}