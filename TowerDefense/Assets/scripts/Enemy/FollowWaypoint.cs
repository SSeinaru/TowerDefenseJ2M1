using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    [SerializeField] private Path path;
    [SerializeField] private float speed = 1;

    [SerializeField] private int nextWaypointIndex = 1;
    [SerializeField] private float reachedWaypointClearance = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = path.waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowards();

        if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) <= reachedWaypointClearance)
        {
            nextWaypointIndex += 1;
        }

        if (nextWaypointIndex >= path.waypoints.Length)
        {
            nextWaypointIndex = 0;
        }
    }
    public void MoveTowards()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position, Time.deltaTime * speed);

        
    }

    private void Awake()
    {
        path = FindAnyObjectByType<Path>();
    }
}
