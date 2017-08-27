using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast : MonoBehaviour
{

    public float speed = 12f;
    public float threshold = .4f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.points[waypointIndex];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, target.position) <= threshold)
        {
            SetNextWaypoint();
        }

    }
    //gitignore test
    void SetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            target = Waypoints.points[++waypointIndex];
        }
    }
    void OnDestroy()
    {
        PlayerStats.Money += 10;
    }
}
