using System;
using Core;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Objects
{
    public class LootsOneInChildren : MonoBehaviour
    {
        [SerializeField] GameObject _ItemToLoot;

        private void Start()
        {
            var childrens = gameObject.GetComponentsInChildren<Loot>();
            if (childrens == null) return;
            childrens[Random.Range(0, childrens.Length)].ItemToLoot = _ItemToLoot;

        }
    }
}