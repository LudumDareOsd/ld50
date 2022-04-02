using UnityEngine;

public class Arrow : MonoBehaviour, Projectile
{
    public float damage = 5f;
    public float speed = 0.1f;

    private Enemy target;

    public void Update() {
        if (target == null) {
            Destroy(gameObject);
        } else {
            var step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step); 

            if (Vector2.Distance(transform.position, target.transform.position) < 0.05f) {
                target.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    public void SetTarget(Enemy enemy) {
        target = enemy;
    }

}
