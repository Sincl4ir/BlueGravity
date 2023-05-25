using UnityEngine;

namespace BlueGravity.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _moveAnimator = "Moving";

        private Vector3 _direction;
        private int _moveAnimatorHash;

        private void Start()
        {
            if (!_rigidbody) { TryGetComponent<Rigidbody2D>(out _rigidbody); }
            if (!_animator) { TryGetComponent<Animator>(out _animator); }

            _moveAnimatorHash = Animator.StringToHash(_moveAnimator);
        }

        private void FixedUpdate()
        {
            _direction = Vector3.zero;
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");

            HandleMovement();
        }

        private void HandleMovement()
        {
            if (_direction == Vector3.zero)
            {
                _animator.SetBool(_moveAnimatorHash, false);
                return;
            }

            _animator.SetBool(_moveAnimatorHash, true);
            
            RotateCharacter();
            MoveCharacter();
        }

        private void MoveCharacter()
        {
            _rigidbody.MovePosition(transform.position + _direction * _speed * Time.deltaTime);
        }

        private void RotateCharacter()
        {
            var rot = _direction.x >= 0 ? 0 : 180;
            transform.rotation = Quaternion.Euler(0, rot, 0);
        }
    }
}
//EOF.