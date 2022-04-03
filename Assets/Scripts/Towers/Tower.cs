using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour {
    public GameObject bullet;
    public float reloadSpeed = 0.3f;

    public int uppgradePrice1 = 200;
    public int uppgradePrice2 = 500;

    public int level2Damage = 5;
    public int level3Damage = 7;

    private int level = 1;

    private float reload = 0f;
    private TargetSeeker targetSeeker;
    private SpriteRenderer uppgradeSr;
    private BoxCollider2D uppgradeColl;
    private void Awake() {
        targetSeeker = GetComponentInChildren<TargetSeeker>();
        uppgradeSr = transform.Find("UpgradeCross").GetComponent<SpriteRenderer>();
        uppgradeColl = transform.Find("UpgradeCross").GetComponent<BoxCollider2D>();
        uppgradeSr.enabled = false;
        uppgradeColl.enabled = false;
    }

    private void Start() {
        PlayerManager.instance.AddTower(this);
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
        var projectile = proj.GetComponent<Projectile>();
        projectile.SetTarget(targetSeeker.GetTarget());

        if (level == 2) {
            projectile.SetDamage(level2Damage);
        } else if (level == 3) {
            projectile.SetDamage(level3Damage);
        }
    }

    public void Uppgrade() {
        if (level == 1) {
            if (GameManager.instance.GetMoney() >= uppgradePrice1) {
                this.targetSeeker.GetComponent<CircleCollider2D>().radius += 0.2f;

                GameManager.instance.AddMoney(-uppgradePrice1);
                level++;
            }
        } else if (level == 2) {
            if (GameManager.instance.GetMoney() >= uppgradePrice2) {
                this.targetSeeker.GetComponent<CircleCollider2D>().radius += 0.2f;

                GameManager.instance.AddMoney(-uppgradePrice2);
                level++;
            }
        }
    }

    public void HideUppgrade() {
        uppgradeSr.enabled = false;
        uppgradeColl.enabled = false;
    }

    public void ShowUppgrade(GameObject uppgradePrice) {
        if (level != 3) {

            var tmp = uppgradePrice.GetComponentInChildren<TextMeshProUGUI>();

            if (level == 1) {
                tmp.text = uppgradePrice1.ToString();
            } else if (level == 2) {
                tmp.text = uppgradePrice2.ToString();
            }

            uppgradeColl.enabled = true;
            uppgradeSr.enabled = true;
            uppgradePrice.SetActive(true);

            var textpos = new Vector2(transform.position.x + 0.25f, transform.position.y + 0.17f);

            var pos = RectTransformUtility.WorldToScreenPoint(Camera.main, textpos);
            uppgradePrice.transform.position = pos;
        }
    }
}
