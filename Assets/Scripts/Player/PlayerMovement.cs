using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : UnityEngine.MonoBehaviour
    {
        private Rigidbody2D _rb;
        private PlayerInput _playerInput;
        private Animator _animator;
        [SerializeField] private int _runSpeedBonus = 150;
        
        [SerializeField]
        private float _baseSpeed;
        private bool _isFacingRight = true;
        private float _speed;
        private bool _canJump = true;
        
        [SerializeField] private float _jumpDelay = 0.5f;
        private static readonly int IsMoving = Animator.StringToHash("isMoving");
        private static readonly int Jump1 = Animator.StringToHash("jump");

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
            _animator = GetComponent<Animator>();
            _speed = _baseSpeed;
            GetComponent<PlayerInput>().OnJump += Jump;
        }
        
        private void Update()
        
        {
            
            _animator.SetBool("isRunning", _playerInput.IsRunning);
            _animator.SetFloat("velocity", Mathf.Abs(_playerInput.Horizontal + _playerInput.Vertical));
            
            if (_playerInput.IsRunning)
            {
                _speed = _baseSpeed + _runSpeedBonus;
            }
            else
            {
                _speed = _baseSpeed;
            }
            
            if ((_playerInput.Horizontal > 0 && !_isFacingRight) || (_playerInput.Horizontal < 0 && _isFacingRight))
            {
                Flip();
            }
        }

        private void OnDestroy()
        {
            GetComponent<PlayerInput>().OnJump -= Jump;
        }

        private void Jump()
        {
            Debug.Log("jump");
            if (_canJump)
            {
                _canJump = false;
                _animator.SetTrigger(Jump1);
                StartCoroutine(ResetCanJump());
            }

        }

        private IEnumerator ResetCanJump()
        {
            yield return new WaitForSeconds(_jumpDelay);
            _canJump = true;
        }
        
        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_playerInput.Horizontal * _speed * Time.fixedDeltaTime, _playerInput.Vertical* _speed * Time.fixedDeltaTime);
        }
        
        
        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}