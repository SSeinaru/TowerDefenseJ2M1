using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 1;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
