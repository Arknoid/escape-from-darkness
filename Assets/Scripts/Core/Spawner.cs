using System;
using System.Collections;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

public class Spawner : UnityEngine.MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPos;
    [TagSelector]
    [SerializeField] private string[] _poolObjectsTag;
    [SerializeField] private float _spawnRate = 0.3f;
    
    private bool _isSpawning = false;

    public void StartSpawn(float startDelay = 0f)
    {
        _isSpawning = true;
        StartCoroutine(StartSpawnCoroutine(startDelay));
    }
    
    public void StopSpawn()
    {
        _isSpawning = false;
    }
    
    private IEnumerator StartSpawnCoroutine(float startDelay) {

        yield return new WaitForSeconds(startDelay);
        while (_isSpawning)
        {
            var spawnedObject = ObjectPooler.Instance.GetPooledObject(_poolObjectsTag[Random.Range(0, _poolObjectsTag.Length)]);
            if (spawnedObject != null)
            {
                spawnedObject.transform.position =
                    _spawnPos[Random.Range(0, _spawnPos.Length)].transform.position;
                spawnedObject.SetActive(true);
            }
            yield return new WaitForSeconds(_spawnRate);
        }

    }
}