using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services;

namespace Source.Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;
        public Game() => 
            StateMachine = new GameStateMachine(new SceneLoader(), AllServices.Container);
    }
}