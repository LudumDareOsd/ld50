using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Projectile
{
    void SetTarget(BaseEnemy enemy);

    void SetDamage(float damage);
}
