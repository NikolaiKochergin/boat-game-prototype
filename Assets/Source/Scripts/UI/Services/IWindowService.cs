using Source.Scripts.Services;

namespace Source.Scripts.UI.Services
{
    public interface IWindowService : IService
    {
        void OpenWindow(WindowId windowId);
        void CloseWindow(WindowId windowId);
        void CloseAllWindows();
    }
}