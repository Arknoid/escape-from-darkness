using System;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public delegate void OnJumpHandler();
        public event OnJumpHandler OnJump;

        public bool IsRunning { get; private set; }
        
        private void Update()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            IsRunning = Input.GetButton("Fire1");
            if (Input.GetButtonDown("Jump")) OnJump?.Invoke();
        }
    }
}