using System;

namespace Source.Scripts.Services.Race
{
    public interface IRaceService : IService
    {
        float RedShipPosition { get; }
        float BlueShipPosition { get; }
        event Action RedShipWin;
        event Action BlueShipWin;
        void PrepareToRace();
        void StartRace();
        void Cleanup();
    }
}