using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(FollowPath))]
public class BaseEnemy : MonoBehaviour
{
    public GameObject BloodSplosion;

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
        hb = GetComponent<Healthbar>();
        //hb.low = Color.red;
        //hb.high = Color.green;
    }

    public virtual void Spawn(int wave)
    {
        this.health += (this.health / 3.5f * (wave * 0.85f));
        if(wave >= 8)
        {
            // Above wave 8, adds one tenth of their movespeed for every succesive wave
            GetComponent<FollowPath>().moveSpeed += (GetComponent<FollowPath>().moveSpeed * (0.1f * (wave - 7)));
        }

    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        hb.SetHealth(health, maxHealth);
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
        EnemyManager.instance.EnemyDied();
        Instantiate(BloodSplosion, transform.position, transform.rotation);
    }
    
    public virtual int GateCrash()
    {
        Kill();
        // TODO: Trigger SPLOSION
        return gateDamage;
    }

    public void Kill()
    {
        TakeDamage(health);
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
