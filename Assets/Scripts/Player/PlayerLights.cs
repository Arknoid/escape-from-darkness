using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerLights : MonoBehaviour
    {
        [SerializeField]
        private GameObject _basicLight;
        [SerializeField]
        private GameObject _torch;

        [SerializeField] private float _consumeWoodDelay = 10f;
        

        private bool _isTorchInFlame = false;

        public void InFlameTorch()
        {
            if (_isTorchInFlame) return;
            _isTorchInFlame = true;
            StartCoroutine(ConsumeWood());
        }

        private IEnumerator ConsumeWood()
        {
            while (PlayerItems.Instance.Woods > 0)
            {
                PlayerItems.Instance.Woods--;
                yield return new WaitForSeconds(_consumeWoodDelay);
                
            }
            _isTorchInFlame = false;
        }

        private void Start()
        {
            _basicLight.gameObject.SetActive(true);
            _torch.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (PlayerItems.Instance.Woods > 0 && _isTorchInFlame)
            {
                _basicLight.gameObject.SetActive(false);
                _torch.gameObject.SetActive(true);
            }
            else
            {
                _basicLight.gameObject.SetActive(true);
                _torch.gameObject.SetActive(false);
            }
        }
    }
}