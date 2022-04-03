using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(FollowPath))]
public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    public float health = 10f;
    public int money = 10;

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0.0f)
        {
            OnDeath();
            Destroy(gameObject);
        }
    }

    public virtual void OnDeath()
    {
        GameManager.instance.AddBanished();
        GameManager.instance.AddMoney(money);
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
