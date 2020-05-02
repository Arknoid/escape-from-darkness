using System;
using Core.Interfaces;
using UnityEngine;

namespace Core
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected int _damage = 3;
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            var otherDamageable = other.GetComponent<IDamageable>();
            otherDamageable?.TakeDamage(_damage);
        }
    }
}