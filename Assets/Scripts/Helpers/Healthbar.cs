using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Color low, high;
    public Vector3 offset;

    private GameObject fg;
    private GameObject bg;

    void Start()
    {
        //fg = transform.Find("FG").gameObject;
        //bg = transform.Find("BG").gameObject;
    }

    public void SetHealth(float h, float max)
    {
        //enabled = h < max;

        //slider.gameObject.SetActive(h < max);
        //slider.value = h;
        //slider.maxValue = max;

        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
    void Update()
    {
        //slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }
}
