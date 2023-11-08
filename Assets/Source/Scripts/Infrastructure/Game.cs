using Reflex.Core;
using Source.Scripts.Infrastructure.States;

namespace Source.Scripts.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(Container container) => 
            StateMachine = container.Single<GameStateMachine>();
    }
}