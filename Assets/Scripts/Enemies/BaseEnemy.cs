using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(FollowPath))]
public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    public float health = 10f;
    public int money = 10;
    public int gateDamage = 10;

    private Healthbar hb;
    private float maxHealth = 0;

    void Start()
    {
        maxHealth = health;
        //hb = gameObject.AddComponent(typeof(Healthbar)) as Healthbar;
        //hb = GetComponent<Healthbar>();
        //hb.low = Color.red;
        //hb.high = Color.green;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        //hb.SetHealth(health, maxHealth);
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
    
    public virtual int GateCrash()
    {
        // TODO: Trigger SPLOSION
        TakeDamage(health);
        return gateDamage;
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
