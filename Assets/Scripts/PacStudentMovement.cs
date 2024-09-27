using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    public Transform[] waypoints;    
    public float speed = 5.0f;      
    private int currentWaypointIndex = 0;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            StartCoroutine(MoveToNextWaypoint());
        }
    }

    IEnumerator MoveToNextWaypoint()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = waypoints[currentWaypointIndex].position;
        float journeyLength = Vector3.Distance(startPosition, endPosition);
        float journeyCompleted = 0.0f;

        while (journeyCompleted < 1.0f)
        {
            journeyCompleted += Time.deltaTime / (journeyLength / speed);
            transform.position = Vector3.Lerp(startPosition, endPosition, journeyCompleted);
            yield return null;
        }

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        StartCoroutine(MoveToNextWaypoint());
    }
}
