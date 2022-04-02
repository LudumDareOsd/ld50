using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class LoopSprite : MonoBehaviour
{
	public List<Sprite> sprites;

	[Range(0.0f, 3.0f)]
	public float switchTime = 1f;

	private int currentSprite = 0;
	private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

	void Awake()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine(SwitchSprite(switchTime));
        rb = GetComponent<Rigidbody2D>();
	}

	public IEnumerator SwitchSprite(float duration)
	{
        // float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		currentSprite = (currentSprite >= sprites.Count - 1) ? 0 : currentSprite + 1;
		spriteRenderer.sprite = sprites[currentSprite];

		yield return new WaitForSeconds(duration);

		StartCoroutine(SwitchSprite(duration));
	}
}