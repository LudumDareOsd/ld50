using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class FollowPath : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 2f;

    private Transform currentTarget;
    private Rigidbody2D rb;

    void Awake()
    {
        Transform container = GameObject.Find("Waypoints").transform;
        foreach(Transform child in container)
        {
            currentTarget = child;
            if(child.GetComponent<Waypoint>().startPoint) {
                transform.position = currentTarget.position;
                break;
            }
        }

        rb = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate ()
	{
        Move();
	}

    private void Move()
    {
        // transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);

		// if(currentTarget == null) return;

		// Vector3 deltaPos = currentTarget.position - transform.position;
		// rb.velocity = 1f/Time.fixedDeltaTime * deltaPos * Mathf.Pow(1f, 90f*Time.fixedDeltaTime);

		// Quaternion deltaRot = currentTarget.rotation * Quaternion.Inverse(transform.rotation);

		// float angle;
		// Vector3 axis;

		// deltaRot.ToAngleAxis(out angle, out axis);

		// if (angle > 180.0f) angle -= 360.0f;

		// if (angle != 0) rb.angularVelocity = (1f/Time.fixedDeltaTime * angle * axis * 0.01745329251994f * Mathf.Pow(1f, 90f*Time.fixedDeltaTime));


        if (Vector2.Distance(transform.position, currentTarget.position) < 0.4f)
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
