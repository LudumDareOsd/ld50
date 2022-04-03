using UnityEngine;

public class Arrow : MonoBehaviour, Projectile
{
    public float damage = 5f;
    public float speed = 0.1f;

    private BaseEnemy target;
    private Vector3 latestTargetPos;

    public void Update() {
        var step = speed * Time.deltaTime;

        if (target == null) {
            transform.position = Vector2.MoveTowards(transform.position, latestTargetPos, step);

            RotateTowards(latestTargetPos);

            if (Vector2.Distance(transform.position, latestTargetPos) < 0.05f) {
                Destroy(gameObject);
            }
        } else {

            RotateTowards(target.transform.position);

            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);

            latestTargetPos = target.transform.position;

            if (Vector2.Distance(transform.position, target.transform.position) < 0.1f) {
                SFXManager.Instance.TriggerSingleImpactSound();
                target.TakeDamage(damage);
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

    public void SetTarget(BaseEnemy enemy) {
        target = enemy;
    }

}
