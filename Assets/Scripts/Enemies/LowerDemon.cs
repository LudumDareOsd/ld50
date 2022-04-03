using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerDemon : BaseEnemy
{
    public override void OnDeath()
    {
        SFXManager.Instance.TriggerLesserDemonSound();
        base.OnDeath();
    }
}
