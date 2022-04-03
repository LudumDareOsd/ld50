using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEProjectile : MonoBehaviour, Projectile {

    public float damage = 5f;
    public float speed = 0.1f;
    public float aoeRadius = 0.5f;
    public GameObject animation;

    private BaseEnemy target;
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

            if (Vector2.Distance(transform.position, latestTargetPos) < 0.05f) {
                Instantiate(animation, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        } else {

            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);

            latestTargetPos = target.transform.position;

            if (Vector2.Distance(transform.position, target.transform.position) < 0.1f) {
                SFXManager.Instance.TriggerAoeSound(0.7f);

                var colliders = new List<Collider2D>();
                targetCollider.OverlapCollider(contactFilter, colliders);

                foreach (var collider in colliders) {
                    collider.GetComponent<BaseEnemy>().TakeDamage(damage);
                }

                Instantiate(animation, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    public void SetTarget(BaseEnemy enemy) {
        target = enemy;
    }

    public void SetDamage(float damage) {
        this.damage = damage;
    }
}
