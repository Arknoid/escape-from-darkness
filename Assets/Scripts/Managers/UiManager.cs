using System;
using Core;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        [SerializeField] private GameObject _endPanel;
        [SerializeField] private GameObject _startPanel;
        
        private GameObject _player;
        private Health _playerHealth;
        
        
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerHealth = _player.GetComponent<Health>();

        }
        
        
        private void Start()
        {
            _endPanel.gameObject.SetActive(false);
            _startPanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public void CloseStartPanel()
        {
            _startPanel.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        
        public void ShowEndPanel()
        {
            _endPanel.gameObject.SetActive(true);
        }
        
        private void Update()
        {
            _healthBar.Val = _playerHealth.CurrentHealth;
            _silverKeysText.text = PlayerItems.Instance.SilverKeys.ToString();
            _goldKeysText.text = PlayerItems.Instance.GoldKeys.ToString();
            _goldsText.text = PlayerItems.Instance.Golds.ToString();
            _woodsText.text = PlayerItems.Instance.Woods.ToString();
            if (_startPanel.gameObject.activeInHierarchy && (Input.GetButton("Jump") || Input.GetButton("Fire1")))
            {
                CloseStartPanel();
            }
            
        }

        public void RestartGame()
        {
            SoundManager.Instance.StopMusic();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}