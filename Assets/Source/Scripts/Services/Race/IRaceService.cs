using System;

namespace Source.Scripts.Services.Race
{
    public interface IRaceService : IService
    {
        event Action RedShipWin;
        event Action BlueShipWin;
        void PrepareToRace();
        void StartRace();
    }
}