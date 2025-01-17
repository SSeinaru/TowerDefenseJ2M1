using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEditor;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    [Header("references")] 
    [SerializeField] private Rigidbody2D rb;

    [Header("attributes")]
    [SerializeField] private float Speed = 2f;

    public static int ObjectsReachedEnd = 0;
    private Transform target;

    private int pathIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.main.waypoints[pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            
            if(pathIndex >= GameManager.main.waypoints.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                OnEndReached();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = GameManager.main.waypoints[pathIndex];
            }
        }

    }
    private void FixedUpdate()
    {
        Vector2 Direction = (target.position - transform.position).normalized;

        rb.velocity = Direction * Speed;
    }

    public static void EnemyReachedEnd()
    {
        ObjectsReachedEnd++;
        Debug.Log("Objects Destroyed: " + ObjectsReachedEnd);
    }

    void OnEndReached()
    {
        EnemyReachedEnd();
    }
}
