using Core;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Objects
{
    public class Loot : MonoBehaviour
    {
        [SerializeField] private int _chanceToLoot;
        [SerializeField] private GameObject[] _chanceItemToLoot;
        public GameObject ItemToLoot;
        private Health _health;
        private bool _hasLoot = false;
        private bool _isChanceLoot;
        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void Start()
        {
            var randomChanceNumber = Random.Range(0, _chanceToLoot);
            _isChanceLoot = randomChanceNumber <= _chanceToLoot;
        }

        private void Update()
        {
            if (_health.IsDie && !_hasLoot)
            {
                _hasLoot = true;
                if (ItemToLoot != null)
                {
                    GameObject.Instantiate(ItemToLoot, transform.position, quaternion.identity);
                }

                if (_chanceItemToLoot != null && _isChanceLoot)
                {
                    GameObject.Instantiate(_chanceItemToLoot[Random.Range(0, _chanceItemToLoot.Length)], transform.position,
                        quaternion.identity);
                }

            }
        }
    }
}