using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHog : BaseEnemy
{
    public override void OnDeath()
    {
        SFXManager.Instance.TriggerHellHogSound();
        base.OnDeath();
    }
}
