using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.UI.StaticData
{
    [CreateAssetMenu(fileName = "UIConfig", menuName = "Static Data/UI Config")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private List<WindowConfig> _windowConfigs;

        public IEnumerable<WindowConfig> WindowConfigs => _windowConfigs;
    }
}