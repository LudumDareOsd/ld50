using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Waypoint : MonoBehaviour
{
    public Transform[] nextWaypoint;
    public bool startPoint = false;
    public bool endPoint = false;

    private int currentWaypoint = 0;

    void Awake()
    {
        DestroyImmediate(GetComponent<SpriteRenderer>());
        Debug.Log($"Init checkpoint with {nextWaypoint.Length} next");
    }

    public Transform GetNextWaypoint()
    {
        if(currentWaypoint >= nextWaypoint.Length) currentWaypoint = 0;
        Debug.Log($"returning checkpoint {currentWaypoint}");
        return nextWaypoint[currentWaypoint++];
    }

    private void OnEnable()
    {
        Transform container = GameObject.Find("Waypoints").transform;
        transform.parent = container;
    }


}
