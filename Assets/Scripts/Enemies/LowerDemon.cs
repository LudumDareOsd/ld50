using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerDemon : BaseEnemy
{
    public override void TakeDamage(float damage)
    {
        SFXManager.Instance.TriggerLesserDemonSound();
        base.TakeDamage(damage);
    }
}
