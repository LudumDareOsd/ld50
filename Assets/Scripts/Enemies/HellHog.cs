using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHog : BaseEnemy
{
    public override void TakeDamage(float damage)
    {
        SFXManager.Instance.TriggerHellHogSound();
        base.TakeDamage(damage);
    }
}
