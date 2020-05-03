using System;
using System.Collections;
using Player;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Objects
{
    public class Chest : MonoBehaviour
    {
        private Animator _animator;
        private bool _isOpen = false;
        public GameObject ItemToLoot;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D other)  
        {
            if (other.gameObject.CompareTag("Player") && PlayerItems.Instance.GoldKeys >= 1 && !_isOpen)
            {
                PlayerItems.Instance.GoldKeys--;
                _animator.SetTrigger("open");
               StartCoroutine(LootItem());
            }
        }

        private IEnumerator LootItem()
        {
            yield return new WaitForSeconds(1);
            GameObject.Instantiate(ItemToLoot, new Vector3(transform.position.x, transform.position.y - 1 , transform.position.z), quaternion.identity);
        }
        
        
    }
}