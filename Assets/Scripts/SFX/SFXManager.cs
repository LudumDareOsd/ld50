using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioSource audioSource;

    public AudioClip impactBody1;

    public AudioClip impactBody2;

    public AudioClip impactBody3;

    public AudioClip creatureScream1;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void TriggerImpactNoise()
    {
        audioSource.PlayOneShot(impactBody1);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
