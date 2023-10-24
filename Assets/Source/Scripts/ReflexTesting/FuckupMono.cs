using System;
using Reflex.Attributes;
using Source.Scripts.Services.Race;
using UnityEngine;

namespace Source.Scripts.ReflexTesting
{
    public class FuckupMono : MonoBehaviour
    {
        private IRaceService _raceService;


        [Inject]
        private void Construct(IRaceService raceService)
        {
            _raceService = raceService;
        }

        private void Start()
        {
            Debug.Log(_raceService.RedShipPosition);
        }

        private void Update()
        {
            Debug.Log(_raceService.RedShipPosition);
        }
    }
}