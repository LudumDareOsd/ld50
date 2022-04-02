using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    public Transform currentTarget;

    void Awake()
    {
        Transform container = GameObject.Find("Waypoints").transform;
        foreach(Transform child in container)
        {
            currentTarget = child;
            if(child.GetComponent<Waypoint>().startPoint) {
                transform.position = currentTarget.position;
                Debug.Log("Setting target");
                break;
            }
            Debug.Log("skipping target");
        }
    }

	private void Start ()
    {
	}

	private void Update ()
    {
        Move();
	}

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentTarget.position) < 10f)
        {
            Debug.Log($"distance {Vector2.Distance(transform.position, currentTarget.position)}");

            if(currentTarget.gameObject.GetComponent<Waypoint>().endPoint) {
                // The End Is Nigh
                // TODO:Church TAKE DAMAGE

                Destroy(gameObject);
            }

            currentTarget = currentTarget.gameObject.GetComponent<Waypoint>().GetNextWaypoint();
            Debug.Log("Getting next waypoint");
        }
    }
}
