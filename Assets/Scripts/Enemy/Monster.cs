using System.Collections;
using UnityEngine;

namespace Enemy
{
using System;
using Core.Interfaces;
using UnityEngine;

namespace Enemy
{
    public class Monster : UnityEngine.MonoBehaviour
    {
        [SerializeField] private string _targetTag = "Player";
        private Rigidbody2D _rb;
        [SerializeField] private int _damage;
        [SerializeField] private float _speed = 2;
        private Animator _animator;
        [SerializeField]
        private bool _isFacingRight = true;
        [SerializeField]
        private float _attackDelay = 0.5f;

        private bool _canAttack = true;
        
        private GameObject _target;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }   
        
        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag(_targetTag);
        }
        
        private void Update()
        {
            if (_target == null) return;
            transform.rotation.SetLookRotation(_target.transform.position);
            _rb.velocity = (_target.transform.position -_rb.transform.position).normalized * _speed;
            
            if (_rb.velocity.x < 0.1 && _isFacingRight || _rb.velocity.x > 0.1 && !_isFacingRight)
            {
                Flip();
            }
            
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var damageableObject = other.transform.GetComponent<IDamageable>();
            if (damageableObject == null && _canAttack) return;
            damageableObject.TakeDamage(_damage);
            _canAttack = false;
            StartCoroutine(ResetCanAttack());

        }


        private IEnumerator ResetCanAttack()
        {
            yield return new WaitForSeconds(_attackDelay);
            _canAttack = true;
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
}