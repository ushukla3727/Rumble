using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollowup : MonoBehaviour
{

    [SerializeField] private GameObject[] wayPoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    void Update()
    {
        if (Vector2.Distance(wayPoints[currentWaypointIndex].transform.position,transform.position)< 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position,Time.deltaTime*speed);

        

    }
}
