using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherDemon : BaseEnemy
{
    public override void TakeDamage(float damage)
    {
        SFXManager.Instance.TriggerHigherDemonSound();
        base.TakeDamage(damage);
    }
}
