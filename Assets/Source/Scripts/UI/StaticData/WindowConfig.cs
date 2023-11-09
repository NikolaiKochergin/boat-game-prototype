using System;
using Source.Scripts.UI.Services;
using Source.Scripts.UI.Windows;
using UnityEngine;

namespace Source.Scripts.UI.StaticData
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        [AssetReferenceUILabelRestriction("window")]
        public WindowBaseComponentReference Address;
    }
}