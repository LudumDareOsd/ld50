using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodsplotion : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(AdvanceFinalMoments(0.1f, 0));
    }

    public IEnumerator AdvanceFinalMoments(float duration, int currentBloodsplosion)
    {

        spriteRenderer.sprite = sprites[currentBloodsplosion];

        yield return new WaitForSeconds(duration);

        if (currentBloodsplosion < sprites.Length - 2)
        {
            StartCoroutine(AdvanceFinalMoments(duration, currentBloodsplosion + 1));

        }
        else
        {
            Destroy(gameObject);
        }

    }

}
