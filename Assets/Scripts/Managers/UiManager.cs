using System;
using Core;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UiManager : MonoBehaviour
    {

        [SerializeField] private ProgressBar _healthBar;
        [SerializeField] private Text _silverKeysText;
        [SerializeField] private Text _goldKeysText;
        [SerializeField] private Text _goldsText;
        [SerializeField] private Text _woodsText;
        private GameObject _player;
        private Health _playerHealth;
        
        
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerHealth = _player.GetComponent<Health>();
        }

        private void Update()
        {
            _healthBar.Val = _playerHealth.CurrentHealth;
            _silverKeysText.text = PlayerItems.Instance.SilverKeys.ToString();
            _goldKeysText.text = PlayerItems.Instance.GoldKeys.ToString();
            _goldsText.text = PlayerItems.Instance.Golds.ToString();
            _woodsText.text = PlayerItems.Instance.Woods.ToString();
        }
    }
}