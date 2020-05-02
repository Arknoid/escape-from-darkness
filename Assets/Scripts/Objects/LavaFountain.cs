using System;
using Player;
using UnityEngine;

namespace Objects
{
    public class LavaFountain : MonoBehaviour
    {
        private PlayerLights _playerLights;

        private void Start()
        {
            _playerLights = FindObjectOfType<PlayerLights>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && PlayerItems.Instance.Woods > 0)
            {
                _playerLights.InFlameTorch();
            }
        }
    }
}