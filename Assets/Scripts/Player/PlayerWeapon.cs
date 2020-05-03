using System;
using Core;
using UnityEngine;

namespace Player
{
    public class PlayerWeapon : Weapon
    {
        private Animator _playerAnimator;
        [SerializeField] private string _animationName;
        private PlayerInput _playerInput;
        private int _baseDamage;
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerAnimator = _player.GetComponent<Animator>();
            _playerInput = _player.GetComponent<PlayerInput>();
            _baseDamage = _damage;
        }
        
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (_playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(_animationName))
            {
                if (_playerInput.IsRunning)
                {
                    _damage *= 2;
                }
                else
                {
                    _damage = _baseDamage;
                }
                
                base.OnTriggerEnter2D(other);
            }

        }
    }
}