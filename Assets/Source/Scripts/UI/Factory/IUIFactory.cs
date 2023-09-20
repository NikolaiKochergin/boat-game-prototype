using Source.Scripts.Services;
using Source.Scripts.UI.Windows;

namespace Source.Scripts.UI.Factory
{
    public interface IUIFactory : IService
    {
        void CreateUIRoot();
        WindowBase CreateMainMenuWindow();
        WindowBase CreateRacePrepareWindow();
        WindowBase CreateRaceProgressWindow();
        WindowBase CreateRaceOverWindow();
        void Cleanup();
    }
}