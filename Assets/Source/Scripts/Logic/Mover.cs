using UnityEngine;

namespace Source.Scripts.Logic
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField, Min(0)] private float _speed = 1;

        private Vector3 _targetPoint;
        private bool _isFinishMoving;


        private void Update()
        {
            if(!_isFinishMoving)
                SetTargetPoint();
            
            transform.position = Vector3.Lerp(transform.position, _targetPoint,
                _speed * Time.deltaTime);
        }

        public void SetFinishPositionZ(float value)
        {
            _isFinishMoving = true;

            _targetPoint = new Vector3(transform.position.x, transform.position.y, value);
        }

        private void SetTargetPoint() => 
            _targetPoint = transform.position + _playerInput.Direction;
    }
}