using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSeeker : MonoBehaviour
{
	private Enemy target = null;
	private CircleCollider2D targetCollider;
	private ContactFilter2D contactFilter;

	private void Awake() {
		targetCollider = GetComponent<CircleCollider2D>();
		contactFilter = new ContactFilter2D();
		contactFilter.layerMask = LayerMask.GetMask("Target");
	}

	public void Update() {

		if (target == null) {
			var colliders = new List<Collider2D>();
			targetCollider.OverlapCollider(contactFilter, colliders);

			Collider2D farthestCollider = null;

			foreach(var collider in colliders) {
				
			}
		}

	}

}
