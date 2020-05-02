using System;
using Player;
using UnityEngine;

namespace DefaultNamespace
{
    public class Door : UnityEngine.MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player") && PlayerItems.Instance.SilverKeys < 1) return;
            PlayerItems.Instance.SilverKeys--;
            _animator.SetTrigger("open");
        }
    }
}