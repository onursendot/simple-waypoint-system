using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public Waypoint wayPoint;

    public bool sequence;
    public bool random;

    public float changePointDistance = 0.2f;
    public float smoothRotationSpeed = 0.5f;

    int currentPoint = 0;
    float distanceWaypoint;
    int randomPointIndex;

    private void FixedUpdate()
    {
        if (wayPoint != null)
        {
            if(sequence)
            {
                distanceWaypoint = Vector3.Distance(transform.position, wayPoint.points[currentPoint].position);
                if (changePointDistance>=distanceWaypoint)
                {
                    if (currentPoint == wayPoint.points.Count-1)
                        currentPoint = 0;
                    else
                        currentPoint++;
                }
            }
            else if(random)
            {
                distanceWaypoint = Vector3.Distance(transform.position, wayPoint.points[currentPoint].position);
                if (changePointDistance >= distanceWaypoint)
                {
                    randomPointIndex = Random.Range(0, wayPoint.points.Count);
                    currentPoint = randomPointIndex;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, wayPoint.points[currentPoint].position, speed * Time.deltaTime);

            // Smooth Rotation
            Vector3 targetDir = wayPoint.points[currentPoint].position - transform.position;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDir), Time.time * smoothRotationSpeed);

        }
    }

}
