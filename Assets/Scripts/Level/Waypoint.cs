using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Waypoint : MonoBehaviour
{
    public Transform[] nextWaypoint = new Transform[0];
    public bool startPoint = false;
    public bool endPoint = false;

    private int currentWaypoint = 0;

    void OnDrawGizmos()
    {
        foreach (Transform next in nextWaypoint)
        {
            if(next != null) {
                Debug.DrawLine(transform.position, next.position, Color.green);
            }
        }
    }

    public Transform GetNextWaypoint()
    {
        if(currentWaypoint >= nextWaypoint.Length) currentWaypoint = 0;
        return nextWaypoint[currentWaypoint++];
    }

    private void OnEnable()
    {
        Transform container = GameObject.Find("Waypoints").transform;
        transform.parent = container;
    }


}
