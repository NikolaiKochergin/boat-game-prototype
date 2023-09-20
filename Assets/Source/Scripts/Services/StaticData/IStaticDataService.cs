using Source.Scripts.UI.Services;
using Source.Scripts.UI.StaticData;

namespace Source.Scripts.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        WindowConfig ForWindow(WindowId windowId);
    }
}