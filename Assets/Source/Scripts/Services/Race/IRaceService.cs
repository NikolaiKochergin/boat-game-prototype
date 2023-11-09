using System;
using Cysharp.Threading.Tasks;

namespace Source.Scripts.Services.Race
{
    public interface IRaceService : IService
    {
        float RedShipPosition { get; }
        float BlueShipPosition { get; }
        event Action RedShipWin;
        event Action BlueShipWin;
        UniTaskVoid PrepareToRace();
        void StartRace();
        void Cleanup();
    }
}