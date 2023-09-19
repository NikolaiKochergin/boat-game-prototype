using UnityEngine;

namespace Source.Scripts.Logic
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField, Min(0)] private float _speed = 1;

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + _playerInput.Direction,
                _speed * Time.deltaTime);
        }
    }
}