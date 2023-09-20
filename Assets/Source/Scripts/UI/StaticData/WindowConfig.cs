using System;
using Source.Scripts.UI.Services;
using Source.Scripts.UI.Windows;

namespace Source.Scripts.UI.StaticData
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase Prefab;
    }
}