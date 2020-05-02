using System;
using System.Collections;
using System.Collections.Generic;
using Core.Interfaces;
using Patterns;
using UnityEngine;

namespace Player
{
    public enum Weapons
    {
        Jump,
        Knife,
        RustySword,
    }
    public class PlayerWeaponsManager : MonoSingleton<PlayerWeaponsManager>
    {
        private PlayerMovement _playerMovement;
        private PlayerInput _playerInput;
        private Animator _animator;
        
        private bool _canAttack = true;
        [SerializeField] private float _jumpDelay = 0.5f;
        private static readonly int Jump1 = Animator.StringToHash("jump");
        
        [SerializeField] private int _jumpAttackDamage = 1;
        [SerializeField] private int _runJumpAttackDamage = 3;

        [SerializeField] private GameObject _knifeWeapon;
        [SerializeField] private GameObject _swordWeapon;
        private Weapons _currentWeapon;
        private static readonly int KnifeAttack = Animator.StringToHash("knifeAttack");
        private static readonly int RustySwordAttack = Animator.StringToHash("rustySwordAttack");

        public Weapons CurrentWeapon
        {
            get => _currentWeapon;
            set
            {
                _currentWeapon = value;
                UpdateWeapon();
            }
        }
        private void Awake()
        {
            CurrentWeapon = Weapons.RustySword;
            _animator = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerInput = GetComponent<PlayerInput>();
            GetComponent<PlayerInput>().OnJump += Attack;
        }
        
        private void UpdateWeapon()
        {
            switch (CurrentWeapon)
            {
                case Weapons.Jump : 
                    _swordWeapon.SetActive(false);
                    _knifeWeapon.SetActive(false);
                    break;
                case Weapons.Knife :
                    _swordWeapon.SetActive(false);
                    _knifeWeapon.SetActive(true);
                    break;
                case Weapons.RustySword :
                    _swordWeapon.SetActive(true);
                    _knifeWeapon.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        
        private void OnDestroy()
        {
            GetComponent<PlayerInput>().OnJump -= Attack;
        }

        private void Attack()
        {
            if (!_canAttack) return;
            _canAttack = false;
            
            switch (CurrentWeapon)
            {
                case Weapons.Jump :
                    _animator.SetTrigger(Jump1);
                    break;
                case Weapons.Knife :
                    _animator.SetTrigger(KnifeAttack);
                    break;
                case Weapons.RustySword :
                    _animator.SetTrigger(RustySwordAttack);
                    break;
                default:
                    break;
            }
            
            StartCoroutine(ResetCanAttack());

        }
        
        private IEnumerator ResetCanAttack()
        {
            yield return new WaitForSeconds(_jumpDelay);
            _canAttack = true;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            
            var damageableObject = other.transform.GetComponent<IDamageable>();
            if (damageableObject == null) return;
            
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                damageableObject.TakeDamage(_playerInput.IsRunning ? _runJumpAttackDamage : _jumpAttackDamage);
            }
        }
    }
}