using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEProjectile : MonoBehaviour, Projectile {

    public float damage = 4f;
    public float speed = 0.1f;

    private Enemy target;
    private Vector3 latestTargetPos;

    // Update is called once per frame
    void Update() {
        var step = this.speed * Time.deltaTime;

        if (this.target == null) {
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.latestTargetPos, step);

            if (Vector2.Distance(this.transform.position, this.latestTargetPos) < 0.05f) {
                Destroy(this.gameObject);
            }
        } else {
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.target.transform.position, step);

            this.latestTargetPos = this.target.transform.position;

            if (Vector2.Distance(this.transform.position, this.target.transform.position) < 0.05f) {
                SFXManager.Instance.TriggerSingleImpactSound();
                this.target.TakeDamage(this.damage);
                Destroy(this.gameObject);
            }
        }
    }

    public void SetTarget(Enemy enemy) {
        this.target = enemy;
    }
}
