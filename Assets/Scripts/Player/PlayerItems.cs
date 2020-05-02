using System;
using System.Security.Cryptography;
using Patterns;
using UnityEngine;

namespace Player
{
    public class PlayerItems : MonoSingleton<PlayerItems>
    {
        [SerializeField] private int _silverKeys = 0;
        [SerializeField] private int _goldKeys = 0;
        [SerializeField] private int _woods = 0;
        [SerializeField] private int _golds = 0;
        
        public int SilverKeys
        {
            get => _silverKeys;
            set => _silverKeys = value;
        }

        public int GoldKeys
        {
            get => _goldKeys;
            set => _goldKeys = value;
        }

        public int Woods
        {
            get => _woods;
            set => _woods = value;
        }

        public int Golds
        {
            get => _golds;
            set => _golds = value;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("collider");
            switch (other.tag)
            {
                case "Item Silver Key" :
                    SilverKeys++;
                    Destroy(other.gameObject);
                    break;
                case "Item Gold Key" :
                    GoldKeys++;
                    Destroy(other.gameObject);
                    break;
                case "Item Wood" :
                    Destroy(other.gameObject);
                    Woods++;
                    break;
                case "Item Gold" :
                    Destroy(other.gameObject);
                    Golds++;
                    break;
            }
        }

    }
}