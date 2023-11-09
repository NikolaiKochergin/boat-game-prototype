using Source.Scripts.UI.Elements;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Source.Scripts.StaticData
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Static Data/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private UIRootComponentReference _uiRoot;
        [SerializeField] private AssetReferenceT<Material> _material;

        public UIRootComponentReference UIRoot => _uiRoot;
    }
}