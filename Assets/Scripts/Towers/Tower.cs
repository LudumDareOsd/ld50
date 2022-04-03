using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public GameObject bullet;
    public float reloadSpeed = 0.3f;
    private float reload = 0f;
    private TargetSeeker targetSeeker;
    private SpriteRenderer uppgradeSr;
    private void Awake() {
        targetSeeker = GetComponentInChildren<TargetSeeker>();
        uppgradeSr = transform.Find("UpgradeCross").GetComponent<SpriteRenderer>();
        uppgradeSr.enabled = false;
    }

    public void Update() {

        if (reload > 0) {
            reload -= Time.deltaTime;
        }

        if (targetSeeker.GetTarget() != null) {
            if (reload <= 0f) {
                reload = reloadSpeed;
                Fire();
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            HideUppgrade();
        }
    }

    private void Fire() {
        Vector3 vectorToTarget = targetSeeker.GetTarget().transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 270, Vector3.forward);

        var proj = Instantiate(this.bullet, transform.localPosition, Quaternion.Slerp(transform.rotation, q, 1f));
        proj.GetComponent<Projectile>().SetTarget(targetSeeker.GetTarget());
    }

    public void HideUppgrade() {
        uppgradeSr.enabled = false;
    }

    private void OnMouseOver() {
        uppgradeSr.enabled = true;
    }
}
