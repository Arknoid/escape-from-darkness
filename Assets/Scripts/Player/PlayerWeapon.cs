using System;
using Core;
using UnityEngine;

namespace Player
{
    public class PlayerWeapon : Weapon
    {
        private Animator _playerAnimator;
        private PlayerInput _playerInput;
        private int _baseDamage;
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerInput = _player.GetComponent<PlayerInput>();
            _baseDamage = _damage;
        }
        
        
        private void OnTriggerEnter2D(Collider2D other)
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
            _damage = _baseDamage;
        }

        }
}