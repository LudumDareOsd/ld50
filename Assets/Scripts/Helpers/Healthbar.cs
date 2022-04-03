using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public GameObject healthbarPrefab;
    public Color low, high;
    public Vector3 offset;

    private GameObject healthbar;

    void Start()
    {
        healthbar = Instantiate(healthbarPrefab);
        healthbar.SetActive(false);
    }

    public void SetHealth(float h, float max)
    {
        healthbar.SetActive(h < max && h > 0);
        healthbar.transform.localScale = new Vector3(h / max, 1, 1);
        if(h <= 0f)
        {
            Destroy(healthbar);
        }

    }
    void Update()
    {
        healthbar.transform.position = transform.position - offset;
    }
}
