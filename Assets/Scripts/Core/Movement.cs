﻿using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int _speed = 100;
        [SerializeField] private Vector2 _direction = Vector2.up;
        [SerializeField] private bool _useXSinusoid = false;
        [SerializeField] private bool _useRandomFrequencyMultiplier = false;
        [SerializeField] private float _frequency = 1;
        [SerializeField] private float _magnitude = 2f;

        public Vector2 Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                _rb.velocity = _direction * _speed;
            }
        }

        private Rigidbody2D _rb;
        private float _randomFrequencyMultiplier = 1;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            if (_useRandomFrequencyMultiplier)
            {
                _randomFrequencyMultiplier = Random.Range(0.5f, 1f);
            }
           
        }
        
        private void OnEnable()
        {
            // _rb.velocity = _direction * _speed;
        }

        private void FixedUpdate()
        {
            if (_useXSinusoid)
            {
                _rb.velocity = new Vector2(Mathf.Cos( Time.time * _randomFrequencyMultiplier * _frequency ) * _magnitude, _rb.velocity.y ); ;
            }
        }
        
}