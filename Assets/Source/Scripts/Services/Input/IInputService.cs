using Source.Scripts.Logic;
using Source.Scripts.Services.Race;

namespace Source.Scripts.Services.Input
{
    public interface IInputService : IService
    {
        void Initialize(IRaceService raceService, PlayerInput leftPlayer, PlayerInput rightPlayer);
        void EnablePlayerInput();
        void DisablePlayersInput();
        void EnableMenuInput();
        void DisableMenuInput();
    }
}