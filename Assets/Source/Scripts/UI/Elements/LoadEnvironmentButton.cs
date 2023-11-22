using Reflex.Attributes;
using Source.Scripts.Infrastructure.AssetManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Elements
{
    public class LoadEnvironmentButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IAssets _assets;

        private void Awake() => 
            _button.onClick.AddListener(OnButtonClicked);

        [Inject]
        public void Construct(IAssets assets) => 
            _assets = assets;


        private async void OnButtonClicked()
        {
            GameObject prefab = await _assets.Load<GameObject>("All_Environment");

            Instantiate(prefab);
        }
    }
}
