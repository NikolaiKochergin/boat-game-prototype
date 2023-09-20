using Source.Scripts.Data;
using Source.Scripts.Logic;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.Player
{
    public class Ship : MonoBehaviour , ISavedProgress
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Mover _mover;
        [SerializeField] private TriggerObserver _triggerObserver;

        public PlayerInput Input => _playerInput;
        public Mover Mover => _mover;
        public TriggerObserver TriggerObserver => _triggerObserver;
        
        public void LoadProgress(PlayerProgress progress)
        {
        }

        public void UpdateProgress(PlayerProgress progress)
        {
        }
    }
}