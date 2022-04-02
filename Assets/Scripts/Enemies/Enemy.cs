using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    public float health = 10f;
    public string deathSound, spawnSound;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0.0f)
        {
            SFXManager.Instance.TriggerHellHogSound();
            // Die
            Destroy(gameObject);
        }
    }

    public float GetAccumulatedDistance()
    {
        return GetComponent<FollowPath>().accumulatedDistance;
    }

}
