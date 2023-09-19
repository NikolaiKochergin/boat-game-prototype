using UnityEngine;

namespace Source.Scripts.Logic
{
    public class TrackPoint : MonoBehaviour
    {
        private Transform _leftShip;
        private Transform _rightShip;
        
        private void Awake() => 
            enabled = false;

        public void StartTrack(Transform leftShip, Transform rightShip)
        {
            _leftShip = leftShip;
            _rightShip = rightShip;
            enabled = true;
        }

        private void Update() => 
            UpdatePosition();

        private void UpdatePosition() => 
            transform.position = Vector3.Lerp(_leftShip.position, _rightShip.position, 0.5f);
    }
}