using Cysharp.Threading.Tasks;
using Source.Scripts.Services;
using Source.Scripts.UI.Services;
using Source.Scripts.UI.Windows;

namespace Source.Scripts.UI.Factory
{
    public interface IUIFactory : IService
    {
        UniTask CreateUIRoot();
        void Cleanup();
        UniTask<WindowBase> CreateWindow(WindowId id);
        UniTaskVoid WarmUp();
    }
}