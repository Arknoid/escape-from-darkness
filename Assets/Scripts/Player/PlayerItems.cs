using System;
using System.Security.Cryptography;
using Core;
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
        [SerializeField] private int _healthToAdd = 1;
        
        private Health _playerHealth;
        private PlayerWeaponsManager _playerWeaponsManager;
        
        
        private void Start()
        {
            _playerWeaponsManager = GetComponent<PlayerWeaponsManager>();
            _playerHealth = GetComponent<Health>();
        }

        public int SilverKeys
        {
            get => _silverKeys;
            set => _silverKeys = value <= 0 ? 0 : value;
        }

        public int GoldKeys
        {
            get => _goldKeys;
            set => _goldKeys = value <= 0 ? 0 : value;
        }

        public int Woods
        {
            get => _woods;
            set => _woods = value <= 0 ? 0 : value;
        }

        public int Golds
        {
            get => _golds;
            set => _golds  = value <= 0 ? 0 : value;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.tag)
            {
                case "Item Silver Key" :
                    SilverKeys++;
                    other.GetComponent<Collider2D>().enabled = false;
                    Destroy(other.gameObject,0.3f);
                    break;
                case "Item Gold Key" :
                    GoldKeys++;
                    other.GetComponent<Collider2D>().enabled = false;
                    Destroy(other.gameObject,0.3f);
                    break;
                case "Item Wood" :
                    other.GetComponent<Collider2D>().enabled = false;
                    Destroy(other.gameObject,0.3f);
                    Woods++;
                    break;
                case "item Gold" :
                    other.GetComponent<Collider2D>().enabled = false;
                    Destroy(other.gameObject,0.3f);
                    Golds++;
                    break;
                case "potion_blue" :
                    other.GetComponent<Collider2D>().enabled = false;
                    Destroy(other.gameObject,0.3f);
                    break;
                case "potion_red" :
                    other.GetComponent<Collider2D>().enabled = false;
                    _playerHealth.AddHealth(_healthToAdd);
                    Destroy(other.gameObject,0.3f);
                    break;
                case "Item_Knife" :
                    other.GetComponent<Collider2D>().enabled = false;
                    _playerWeaponsManager.CurrentWeapon = Weapons.Knife;
                    Destroy(other.gameObject);
                    break;
                case "Item_Sword" :
                    other.GetComponent<Collider2D>().enabled = false;
                    _playerWeaponsManager.CurrentWeapon = Weapons.Sword;
                    Destroy(other.gameObject);
                    break;
                case "Item_Rusty_Sword" :
                    other.GetComponent<Collider2D>().enabled = false;
                    _playerWeaponsManager.CurrentWeapon = Weapons.RustySword;
                    Destroy(other.gameObject);
                    break;
            }
        }

    }
}