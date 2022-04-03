using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {
    private ContactFilter2D contactFilter;
    private BoxCollider2D targetCollider;
    private SpriteRenderer sr;


    private void Awake() {
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(LayerMask.GetMask("Target"));
        contactFilter.useLayerMask = true;
        contactFilter.useTriggers = true;

        targetCollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();


    }

    private void Update() {
        var colliders = new List<Collider2D>();
        targetCollider.OverlapCollider(contactFilter, colliders);

        foreach (var collider in colliders) {
            var enemy = collider.gameObject.GetComponent<BaseEnemy>();

            GameManager.instance.TakeGateDamage(enemy.gateDamage);
            enemy.GateCrash();

            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage() {

        sr.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        sr.color = Color.white;
    }

}
