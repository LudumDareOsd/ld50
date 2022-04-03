using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenAnimation : MonoBehaviour
{
    public List<Sprite> sprites;

    [Range(0.01f, 3.0f)]
    public float switchTime = 1f;

    private int currentSprite = 0;
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
        StartCoroutine(SwitchSprite(switchTime));
    }

    public IEnumerator SwitchSprite(float duration)
    {
        currentSprite = currentSprite == sprites.Count - 1 ? 0 : currentSprite + 1;

        image.sprite = sprites[currentSprite];

        yield return new WaitForSeconds(duration);

        StartCoroutine(SwitchSprite(duration));
    }
}
