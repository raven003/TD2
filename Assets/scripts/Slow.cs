using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{

    public float speed = 6f;
    public float threshold = .4f;

    private Transform waypoint;
    private int waypointIndex = 0;

    void Start()
    {
        waypoint = Waypoints.points[waypointIndex];
    }

    void Update()
    {
        Vector3 target = new Vector3(waypoint.position.x, waypoint.position.y + 2, waypoint.position.z);
        Vector3 dir = target - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, target) <= threshold)
        {
            SetNextWaypoint();
        }

    }

    void SetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            waypoint = Waypoints.points[++waypointIndex];
        }
    }
    void OnDestroy()
    {
        PlayerStats.Money += 20;
    }
}
