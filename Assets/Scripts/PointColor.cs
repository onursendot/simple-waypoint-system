using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointColor : MonoBehaviour {

    public Color color;
    public float radius = 1f;

    private void OnDrawGizmos()
    {
        color.a = 1;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }

}
