using Source.Scripts.Services;
using Source.Scripts.Services.Race;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows
{
    public class RaceProgressWindow : WindowBase
    {
        [SerializeField] private Slider _leftSlider;
        [SerializeField] private Slider _rightSlider;
        
        private IRaceService _raceService;

        protected override void OnAwake()
        {
            base.OnAwake();
            Construct();
        }

        private void Construct() => 
            _raceService = AllServices.Container.Single<IRaceService>();

        private void Update()
        {
            _leftSlider.value = _raceService.RedShipPosition;
            _rightSlider.value = _raceService.BlueShipPosition;
        }
    }
}