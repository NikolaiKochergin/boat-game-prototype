using Source.Scripts.Logic;

namespace Source.Scripts.Services.Input
{
    public interface IInputService : IService
    {
        void Initialize(PlayerInput leftPlayer, PlayerInput rightPlayer);
        void EnablePlayerInput();
        void DisablePlayersInput();
        void EnableMenuInput();
        void DisableMenuInput();
    }
}