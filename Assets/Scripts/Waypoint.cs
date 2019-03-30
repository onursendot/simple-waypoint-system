using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Waypoint : MonoBehaviour {

    [HideInInspector]
    public List<Transform> points;
    int pCount;

    private void Start()
    {
        pCount = transform.childCount;
        for(int i=0; i<pCount;i++)
        {
            points.Add(transform.GetChild(i).transform);
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < pCount - 1; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }
    }



}
