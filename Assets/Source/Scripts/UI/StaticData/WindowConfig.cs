using System;
using Source.Scripts.UI.Services;
using Source.Scripts.UI.Windows;
using UnityEngine;
using YellowSquad.AssetPath;

namespace Source.Scripts.UI.StaticData
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        [SerializeField] private ResourcesReference<WindowBase> _prefab;

        public string PrefabPath => _prefab.ResourcesPath;
    }
}