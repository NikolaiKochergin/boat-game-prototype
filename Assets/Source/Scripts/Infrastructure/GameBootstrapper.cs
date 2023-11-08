using System;
using System.Collections;
using Reflex.Core;
using Source.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour //, IInstaller
    {
        private Game _game;

        // private IEnumerator Start()
        // {
        //     while (ProjectInstaller.Container == null)
        //     {
        //         yield return null;
        //     }
        //     
        //     Container container = ProjectInstaller.Container;
        //     
        //         Debug.Log($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<{container.Name}>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        //         
        //         _game = container.Construct<Game>();
        //         _game.StateMachine.Enter<BootstrapState>();
        //         DontDestroyOnLoad(this);
        // }

        private void Start()
        {
            DontDestroyOnLoad(this);
            Scene loadScene = SceneManager.LoadScene("LoadingScene", new LoadSceneParameters(LoadSceneMode.Single));
            ReflexSceneManager.PreInstallScene(loadScene,
                descriptor => descriptor.OnContainerBuilt += container =>
                {
                    Debug.Log("---------------------->" + container.Name);
        
                    _game = container.Construct<Game>(); // new Game(container); // container.Construct<Game>();
                    _game.StateMachine.Enter<BootstrapState>();
                });
        }

        // private void Start()
        // {
        //     DontDestroyOnLoad(this);
        //     Scene loadScene = SceneManager.LoadScene("LoadingScene", new LoadSceneParameters(LoadSceneMode.Single));
        //     ReflexSceneManager.PreInstallScene(loadScene, descriptor =>
        //     {
        //     });
        // }

        // public void InstallBindings(ContainerDescriptor descriptor)
        // {
        //     descriptor.OnContainerBuilt += container =>
        //     {
        //         Debug.Log($"<<<<<<<<<<<<<<<<<<<<<<<<<<<<<{container.Name}>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        //         
        //         _game = container.Parent.Construct<Game>();
        //         _game.StateMachine.Enter<BootstrapState>();
        //         DontDestroyOnLoad(this);
        //     };
        // }
        // public void InstallBindings(ContainerDescriptor descriptor)
        // {
        //     descriptor.OnContainerBuilt += container =>
        //     {
        //         Debug.Log("Check");
        //         _game = container.Construct<Game>();
        //         _game.StateMachine.Enter<BootstrapState>();
        //         DontDestroyOnLoad(this);
        //     };
        // }
    }
}