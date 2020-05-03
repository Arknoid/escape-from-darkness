using System;
using Player;
using UnityEngine;

namespace Objects
{
    public class EndDoor : UnityEngine.MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && PlayerItems.Instance.GoldKeys >= 1)
            {
                PlayerItems.Instance.GoldKeys--;
                _animator.SetTrigger("open");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("youwin");
        }
    }
}