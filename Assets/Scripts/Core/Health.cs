using System.Collections;
using Core.Interfaces;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _health = 10;
        [SerializeField] private int  _maxHealth = 100;
        [SerializeField] private string _animatorTriggerHit = "hit";
        [SerializeField] private string _animatorTriggerExplode = "explode";
        [SerializeField] private AudioClip _soundHit;
        [SerializeField] private AudioClip _soundExplode;
        [SerializeField] private bool _disableWhenDie = true;
        [SerializeField] private bool _rebootGameOnDie = false;
        [SerializeField] private float _dieTimer = 1f;
        
        public int CurrentHealth
        {
            get => _currentHealth;
            protected set => _currentHealth = value;
        }

        public virtual void AddHealth(int amount)
        {
            _currentHealth += amount;
        }
        
        public bool IsDie => _currentHealth <= 0;
        private int _currentHealth;
        private Animator _animator;
        private Collider2D _collider;

        protected void Start()
        {
            _currentHealth = _health;
        }

        protected void OnEnable()
        {
            _animator.Rebind();
        }

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
        }
        public virtual void TakeDamage(int damageTaken)
        {
            if (_soundHit != null)
            {
                SoundManager.Instance.PlaySingle(_soundHit);
            }
            _currentHealth -= damageTaken;
            _animator.SetTrigger(_animatorTriggerHit);
            if (_currentHealth > 0) return;
            StartCoroutine(Explode());
        }

        protected virtual IEnumerator Explode()
        {
            _collider.enabled = false;
            if (_soundExplode != null)
            {
                SoundManager.Instance.PlaySingle(_soundExplode);
            }
            _animator.SetTrigger(_animatorTriggerExplode);
            yield return new WaitForSeconds(_dieTimer);
            if (_rebootGameOnDie)
            {
                SoundManager.Instance.StopMusic();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
            if (_disableWhenDie)
            {
                _currentHealth = _health;
                this.gameObject.SetActive(false);
            }


        }


    }
    
}