using System;
using Core.Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerInput _playerInput;
        private Animator _animator;
        [SerializeField] private int jumpAttackDamage = 1;
        [SerializeField] private int speedJumpAttackDamage = 3;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var gm = other.transform.GetComponent<IDamageable>();
            if (gm == null) return;
  
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"));
            {
                gm.TakeDamage(_playerInput.IsRunning ? speedJumpAttackDamage : jumpAttackDamage);
            }
        }
    }
}