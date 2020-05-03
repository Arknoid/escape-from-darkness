using Core;
using UnityEngine;

namespace Enemy
{
    public class MonsterHealth : Health
    {
        private Rigidbody2D _rigidbody2D;

        protected override void Awake()
        {
            base.Awake();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public override void TakeDamage(int damageTaken)
        {
            base.TakeDamage(damageTaken);
            _rigidbody2D.AddForce(new Vector2(-_rigidbody2D.velocity.x, _rigidbody2D.velocity.y));
        }
    }
}