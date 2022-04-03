using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {
    public Sprite doorDamage;
    private Sprite door;
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

        door = sr.sprite;
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

        sr.sprite = doorDamage;

        yield return new WaitForSeconds(0.05f);

        sr.sprite = door;

        yield return new WaitForSeconds(0.05f);

        sr.sprite = doorDamage;

        yield return new WaitForSeconds(0.05f);

        sr.sprite = door;
    }

}
