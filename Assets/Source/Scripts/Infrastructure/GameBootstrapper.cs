using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services;
using UnityEngine;

namespace Source.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private VServices _vServices;
        
        private Game _game;

        private void Start()
        {
            _game = new Game(_vServices);
            _game.StateMachine.RegisterStates();
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}