using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    public float health = 10f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0.0f)
        {
            SFXManager.Instance.TriggerHellHogSound();
            Destroy(gameObject);
        }
    }

    public float GetAccumulatedDistance()
    {
        return GetComponent<FollowPath>().accumulatedDistance;
    }

    public void TriggerSlowdown()
    {
        GetComponent<FollowPath>().TriggerSlowdown();
    }

}
