using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class LoopSprite : MonoBehaviour
{
	public List<Sprite> sprites;

	[Range(0.01f, 3.0f)]
	public float switchTime = 1f;

	private int currentSprite = 0;
	private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

	void Awake()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
		StartCoroutine(SwitchSprite(switchTime));
	}

	public IEnumerator SwitchSprite(float duration)
	{
        var dir = gameObject.GetComponent<FollowPath>().GetDirection();
        bool flip = false;
        if (dir > 4)
        {
            dir = 4;
            flip = true;
        }

        currentSprite = (currentSprite >= 1) ? 0 : currentSprite + 1;
        // Debug.Log(dir + currentSprite);
		spriteRenderer.sprite = sprites[dir + currentSprite];
        spriteRenderer.flipX = flip;

		yield return new WaitForSeconds(duration);

		StartCoroutine(SwitchSprite(duration));
	}
}