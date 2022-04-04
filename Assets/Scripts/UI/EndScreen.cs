using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private float delay = 0f;

    private void Awake()
    {
        var banished = GameObject.Find("EndBanished").GetComponent<TextMeshProUGUI>();
        var wave = GameObject.Find("EndWave").GetComponent<TextMeshProUGUI>();
        banished.text = GameManager.score.banished.ToString();
        wave.text = GameManager.score.wave.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;

        if (Input.anyKey)
        {
            if(delay > 1) {
                GameManager.instance.Restart();
            }
        }
        
    }
}
