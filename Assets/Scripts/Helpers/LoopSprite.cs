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

    private int dir = 0;
    bool flip = false;

	void Awake()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
		StartCoroutine(SwitchSprite(switchTime));
	}

    void LateUpdate()
    {
        dir = GetComponent<FollowPath>().GetDirection();
        if (dir > 4)
        {
            flip = true;
        }

        spriteRenderer.sprite = sprites[Mathf.Min(dir + currentSprite, sprites.Count - 1)];
        //spriteRenderer.flipX = flip;
    }

	public IEnumerator SwitchSprite(float duration)
	{
        var dir = GetComponent<FollowPath>().GetDirection();

        currentSprite = (currentSprite >= 1) ? 0 : currentSprite + 1;

		yield return new WaitForSeconds(duration);

		StartCoroutine(SwitchSprite(duration));
	}
}