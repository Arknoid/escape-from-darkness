using System;
using Core;
using UnityEngine;

namespace Player
{
    public class PlayerWeapon : Weapon
    {
        private Animator _playerAnimator;
        [SerializeField] private string _animationName;
        
        private void Start()
        {
            _playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (_playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(_animationName))
            {
                base.OnTriggerEnter2D(other);
            }

        }
    }
}