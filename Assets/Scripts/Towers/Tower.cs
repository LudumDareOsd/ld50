using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	public GameObject bullet;
	public float reloadSpeed = 0.3f;
	private float reload = 0f;
	private TargetSeeker targetSeeker;
	private void Awake() {
		targetSeeker = GetComponentInChildren<TargetSeeker>();
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
	}

	private void Fire() {
		var proj = Instantiate(bullet, transform.localPosition, transform.rotation);
		proj.GetComponent<Projectile>().SetTarget(targetSeeker.GetTarget());
	}

}
