using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellPriest : BaseEnemy
{
    public override void OnDeath()
    {
        SFXManager.Instance.TriggerHellPriestSound();
        base.OnDeath();
    }
}
