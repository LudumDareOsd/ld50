using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherDemon : BaseEnemy
{
    public override void OnDeath()
    {
        SFXManager.Instance.TriggerHigherDemonSound();
        base.OnDeath();
    }
}
