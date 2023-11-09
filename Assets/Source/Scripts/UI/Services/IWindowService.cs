using Cysharp.Threading.Tasks;
using Source.Scripts.Services;

namespace Source.Scripts.UI.Services
{
    public interface IWindowService : IService
    {
        UniTaskVoid OpenWindow(WindowId windowId);
        void CloseWindow(WindowId windowId);
        void CloseAllWindows();
    }
}