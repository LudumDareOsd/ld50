using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSeeker : MonoBehaviour
{
	public float range;
	private Enemy target = null;
	private CircleCollider2D targetCollider;
	private ContactFilter2D contactFilter;

	private void Awake() {
		targetCollider = GetComponent<CircleCollider2D>();
		targetCollider.radius = range;
		contactFilter = new ContactFilter2D();
		contactFilter.SetLayerMask(LayerMask.GetMask("Target"));
		contactFilter.useLayerMask = true;
		contactFilter.useTriggers = true;
	}

	public Enemy GetTarget() {
		return target;
	}

	public void Update() {

		if (target == null) {
			var colliders = new List<Collider2D>();
			targetCollider.OverlapCollider(contactFilter, colliders);

			Enemy farthestEnemy = null;

			foreach (var collider in colliders) {

				var enemy = collider.gameObject.GetComponent<Enemy>();

				if (farthestEnemy == null) {
					farthestEnemy = enemy;
				} else {
					if (farthestEnemy.GetAccumulatedDistance() < enemy.GetAccumulatedDistance()) {
						farthestEnemy = enemy;
					}
				}
			}

			target = farthestEnemy;
		} else {
			var colliders = new List<Collider2D>();
			targetCollider.OverlapCollider(contactFilter, colliders);

			var isWithinRange = false;

			foreach (var collider in colliders) {
				var enemyColl = collider.GetComponent<Enemy>();

				if (enemyColl.Equals(target)) {
					isWithinRange = true;
					break;
				}
			}

			if (!isWithinRange) {
				target = null;
			}
		}

	}

}
