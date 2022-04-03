using UnityEngine;

public class Arrow : MonoBehaviour, Projectile
{
    public float damage = 5f;
    public float speed = 0.1f;

    private Enemy target;
    private Vector3 latestTargetPos;

    public void Update() {
        var step = speed * Time.deltaTime;

        if (target == null) {
            transform.position = Vector2.MoveTowards(transform.position, latestTargetPos, step);

            if (Vector2.Distance(transform.position, latestTargetPos) < 0.05f) {
                Destroy(gameObject);
            }
        } else {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);

            latestTargetPos = target.transform.position;

            if (Vector2.Distance(transform.position, target.transform.position) < 0.05f) {
                SFXManager.Instance.TriggerSingleImpactSound();
                target.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    public void SetTarget(Enemy enemy) {
        target = enemy;
    }

}
