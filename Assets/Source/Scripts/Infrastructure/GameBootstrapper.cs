using Source.Scripts.Infrastructure.States;
using UnityEngine;

namespace Source.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Start()
        {
            _game = new Game();
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}