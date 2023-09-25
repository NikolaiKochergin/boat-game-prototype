using Source.Scripts.Infrastructure.States;
using VContainer.Unity;

namespace Source.Scripts.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;
        public Game(LifetimeScope resolver) => 
            StateMachine = new GameStateMachine(resolver.Container);
    }
}