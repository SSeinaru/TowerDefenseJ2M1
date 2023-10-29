using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefab;


    [Header("attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5.0f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy;

    public Vector2 spawnPosition;
    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Start()
    {
      

        StartWave();
    }
    private void Update()
    {
        if (!isSpawning) return; 
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemies();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0;
        }
    }
    private void StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void SpawnEnemies()
    {
        GameObject prefabSpawn = enemyPrefab[0];
        Instantiate(prefabSpawn, GameManager.main.pathStart.position, quaternion.identity) ;
    }
    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    public void SetSpawnPosition(Vector2 position)
    {
        spawnPosition = position;
    }


}
