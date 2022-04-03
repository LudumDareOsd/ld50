using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    private ContactFilter2D contactFilter;
    private BoxCollider2D targetCollider;

    private void Awake() {
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(LayerMask.GetMask("Target"));
        contactFilter.useLayerMask = true;
        contactFilter.useTriggers = true;

        targetCollider = GetComponent<BoxCollider2D>();

    }

    private void Update() {

        var colliders = new List<Collider2D>();
        targetCollider.OverlapCollider(contactFilter, colliders);

        BaseEnemy farthestEnemy = null;

        foreach (var collider in colliders) {
            var enemy = collider.gameObject.GetComponent<BaseEnemy>();

            if (farthestEnemy == null) {
                farthestEnemy = enemy;
            } else {
                if (farthestEnemy.GetAccumulatedDistance() < enemy.GetAccumulatedDistance()) {
                    farthestEnemy = enemy;
                }
            }
        }
    }
}
