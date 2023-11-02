using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    public Vector2 spawnPosition;
    public int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    public static int ObjectsDestroyed = 0;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void Start()
    {
        StartCoroutine(StartWave()); ;

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


        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }

        if (currentWave == 4 && ObjectsDestroyed >= 39)
        {
            SceneManager.LoadScene(2);
        }
        else if (FollowWaypoint.ObjectsReachedEnd == 8)
        {
            SceneManager.LoadScene(3);
        }
    }
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn= 0f;
        currentWave++;
        StartCoroutine(StartWave()); ;
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

    public static void ObjectDestroyed()
    {
        ObjectsDestroyed++;
        Debug.Log("Objects Destroyed: " + ObjectsDestroyed);
    }


}
