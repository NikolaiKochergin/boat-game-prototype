using Source.Scripts.Infrastructure.States;
using VContainer;

namespace Source.Scripts.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;
        public Game(IObjectResolver resolver) => 
            StateMachine = resolver.Resolve<GameStateMachine>();
    }
}