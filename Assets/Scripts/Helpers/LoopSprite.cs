using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSprite : MonoBehaviour
{
	public List<Sprite> sprites;

	[Range(0.0f, 3.0f)]
	public float switchTime = 1f;

	private int currentSprite = 0;
	private SpriteRenderer spriteRenderer;

	void Awake()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine(SwitchSprite(switchTime));
	}

	public IEnumerator SwitchSprite(float duration)
	{
		currentSprite = (currentSprite >= sprites.Count - 1) ? 0 : currentSprite + 1;
		spriteRenderer.sprite = sprites[currentSprite];

		yield return new WaitForSeconds(duration);

		StartCoroutine(SwitchSprite(duration));
	}
}