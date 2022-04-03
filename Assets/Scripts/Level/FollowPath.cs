using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class FollowPath : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 2f;
    public float accumulatedDistance = 0f;

    private Vector2 lastPosition;
    private Transform currentTarget;
    private Rigidbody2D rb;
    private float moveAngle = 0f;
    private bool slowdown = false;

    void Awake()
    {
        Transform container = GameObject.Find("Waypoints").transform;
        foreach(Transform child in container)
        {
            currentTarget = child;
            if(child.GetComponent<Waypoint>().startPoint) {
                transform.position = currentTarget.position;
                lastPosition = transform.position;
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
		if(currentTarget == null) return;

        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, (slowdown ? moveSpeed * .5f : moveSpeed) * Time.fixedDeltaTime);

        accumulatedDistance += Vector2.Distance(lastPosition, transform.position);
        moveAngle = GetAngle(lastPosition, transform.position);
        lastPosition = transform.position;


        if (Vector2.Distance(transform.position, currentTarget.position) < 0.01f)
        {
            if(currentTarget.gameObject.GetComponent<Waypoint>().endPoint) {
                // The End Is Nigh
                //Destroy(gameObject);
                GetComponent<BaseEnemy>().Kill();
            }

            currentTarget = currentTarget.gameObject.GetComponent<Waypoint>().GetNextWaypoint();
            // Debug.Log($"Getting next waypoint GetDirection() {GetDirection()}");
        }
    }

    public void TriggerSlowdown()
    {
        slowdown = true;
        StopAllCoroutines();
        StartCoroutine(RemoveSlowness(2f));
    }

    public int GetDirection()
    {
        if (moveAngle >= 60 && moveAngle <= 120)
        {
            // print("N");
            return 0;
        }
        if (moveAngle >= 240 && moveAngle <= 300)
        {
            // print("S");
            return 2;
        }
        if (moveAngle >= 330 && moveAngle <= 360 || moveAngle >= 0 && moveAngle <= 30)
        {
            // print("E");
            return 4;
        }
        if (moveAngle >= 150 && moveAngle <= 210)
        {
            // print("W");
            return 6;
        }
        return 0;
    }

    private float GetAngle(Vector2 A, Vector2 B)
    {
        var delta = B - A;
        var angleRadians = Mathf.Atan2(delta.y, delta.x);
        var angleDegrees = angleRadians * Mathf.Rad2Deg;
        if (angleDegrees < 0) angleDegrees += 360;
        return angleDegrees;
    }

    private IEnumerator RemoveSlowness(float duration)
    {
        yield return new WaitForSeconds(duration);
        slowdown = false;
    }
}
