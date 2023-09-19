using UnityEngine;

namespace Source.Scripts.Logic
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _power = 1;
        [SerializeField, Min(0.01f)] private float _reductionSpeed = 0.5f;

        private float _forwardOffset = 0;
        public Vector3 Direction { get; private set; } = Vector3.zero;

        private void Update()
        {
            if (_forwardOffset > 0)
                _forwardOffset = Mathf.MoveTowards(_forwardOffset, 0, _reductionSpeed * Time.deltaTime);

            Direction = new Vector3(0, 0, _forwardOffset);
        }

        public void AddMovePower() => 
            _forwardOffset += _power;
    }
}