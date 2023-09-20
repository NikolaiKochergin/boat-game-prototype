using System.Collections.Generic;
using Source.Scripts.UI.Factory;
using Source.Scripts.UI.Windows;

namespace Source.Scripts.UI.Services
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;
        private readonly Dictionary<WindowId, WindowBase> _openedWindows = new Dictionary<WindowId, WindowBase>();

        public WindowService(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void OpenWindow(WindowId windowId)
        {
            switch (windowId)
            {
                case WindowId.SettingsMenu:
                    _openedWindows.Add(WindowId.SettingsMenu, _uiFactory.CreateMainMenuWindow());
                    break;
                case WindowId.RacePrepare:
                    _openedWindows.Add(WindowId.RacePrepare, _uiFactory.CreateRacePrepareWindow());
                    break;
                case WindowId.RaceProgress:
                    _openedWindows.Add(WindowId.RaceProgress, _uiFactory.CreateRaceProgressWindow());
                    break;
                case WindowId.RaceOver:
                    _openedWindows.Add(WindowId.RaceOver, _uiFactory.CreateRaceOverWindow());
                    break;
            }
        }

        public void CloseWindow(WindowId windowId)
        {
            if (_openedWindows.TryGetValue(windowId, out WindowBase window))
            {
                _openedWindows.Remove(windowId);
                window.Close();
            }
        }

        public void CloseAllWindows()
        {
            foreach (WindowBase window in _openedWindows.Values) 
                window.Close();
            
            _openedWindows.Clear();
        }
    }
}