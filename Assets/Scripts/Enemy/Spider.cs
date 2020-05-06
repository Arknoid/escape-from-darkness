using System;
using System.Collections;
using Core.Interfaces;
using UnityEngine;

namespace Enemy
{
    public class Spider : UnityEngine.MonoBehaviour
    {
        [SerializeField] private string _targetTag = "Player";
        [SerializeField] private float _attackDelay = 1.5f;
        
        private Rigidbody2D _rb;
        [SerializeField] private int _damage;
        [SerializeField] private float _speed = 2;
        private Animator _animator;
        private bool _isFacingRight = false;
        private bool _canAttack = false;
        
        private GameObject _target;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }   
        
        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag(_targetTag);
            StartCoroutine(ResetCanAttack());
        }

        private IEnumerator ResetCanAttack()
        {
            yield return  new WaitForSeconds(_attackDelay);
            _canAttack = true;
        }
        private void Update()
        {
            if (_target == null) return;
            transform.rotation.SetLookRotation(_target.transform.position);
            
            if (_target.transform.position.x - _rb.transform.position.x > -1f && _target.transform.position.x - _rb.transform.position.x < 1f && _canAttack)
            {
                _animator.SetTrigger("attack");
                _canAttack = false;
                StartCoroutine(ResetCanAttack());
                return;
            }
            
            
            
            _rb.velocity = (_target.transform.position -_rb.transform.position).normalized * _speed;
            if (_rb.velocity.x < 0.1 && _isFacingRight || _rb.velocity.x > 0.1 && !_isFacingRight)
            {
                Flip();
            }
            
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var damageableObject = other.transform.GetComponent<IDamageable>();
            if (damageableObject == null) return;
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                damageableObject.TakeDamage(_damage);
            }
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