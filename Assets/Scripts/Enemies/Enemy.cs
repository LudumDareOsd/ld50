using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    public float Health = 10f;

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0.0f)
        {
            // Die
        }
    }

    public float GetAccumulatedDistance()
    {
        return GetComponent<FollowPath>().accumulatedDistance;
    }

}
