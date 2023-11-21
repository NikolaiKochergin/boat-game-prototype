using Reflex.Attributes;
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

        [Inject]
        private void Construct(IRaceService raceService)
        {
            _raceService = raceService;
        }

        private void Update()
        {
            _leftSlider.value = _raceService.RedShipPosition;
            _rightSlider.value = _raceService.BlueShipPosition;
        }
    }
}