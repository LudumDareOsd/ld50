using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowProjectile : MonoBehaviour, Projectile {
    public float damage = 1f;
    public float slow = 1f;
    public float speed = 0.1f;
    public float aoeRadius = 0.5f;

    private Enemy target;
    private Vector3 latestTargetPos;
    private ContactFilter2D contactFilter;
    private CircleCollider2D targetCollider;

    private void Awake() {
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(LayerMask.GetMask("Target"));
        contactFilter.useLayerMask = true;
        contactFilter.useTriggers = true;

        targetCollider = GetComponent<CircleCollider2D>();
        targetCollider.radius = aoeRadius;
    }

    public void Update() {
        var step = speed * Time.deltaTime;

        if (target == null) {
            transform.position = Vector2.MoveTowards(transform.position, latestTargetPos, step);

            RotateTowards(latestTargetPos);

            if (Vector2.Distance(transform.position, latestTargetPos) < 0.1f) {
                Destroy(gameObject);
            }
        } else {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);

            latestTargetPos = target.transform.position;

            RotateTowards(latestTargetPos);

            if (Vector2.Distance(transform.position, target.transform.position) < 0.05f) {
                SFXManager.Instance.TriggerSlowSound();

                var colliders = new List<Collider2D>();
                targetCollider.OverlapCollider(contactFilter, colliders);

                foreach (var collider in colliders) {
                    var enemy = collider.GetComponent<Enemy>();
                    enemy.TakeDamage(damage);
                    // enemy.Slow();
                }

                Destroy(gameObject);
            }
        }
    }

    private void RotateTowards(Vector3 position) {
        Vector3 vectorToTarget = position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 270, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10f);
    }

    public void SetTarget(Enemy enemy) {
        target = enemy;
    }
}
