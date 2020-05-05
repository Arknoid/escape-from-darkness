using System;
using Managers;
using Player;
using UnityEngine;

namespace Objects
{
    public class EndDoor : UnityEngine.MonoBehaviour
    {
        private Animator _animator;
        private UiManager _uiManager;
        private bool _isOpen = false;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _uiManager = FindObjectOfType<UiManager>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && PlayerItems.Instance.GoldKeys >= 1)
            {
                PlayerItems.Instance.GoldKeys--;
                _animator.SetTrigger("open");
                _isOpen = true;
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isOpen)
            {
                Time.timeScale = 0f;
                 _uiManager.ShowEndPanel();
            }
        }
        
    }
}