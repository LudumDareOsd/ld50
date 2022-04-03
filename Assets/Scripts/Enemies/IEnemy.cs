using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    //public Transform transform { get; }

    public void TakeDamage(float damage);

    public float GetAccumulatedDistance();

    public void TriggerSlowdown();
}
