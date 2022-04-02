using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioSource audioSource;

    private bool isUsingAudioSource;

    [SerializeField]
    public AudioClip[] impacts;

    private int impactsIndex = 0;

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

    private IEnumerator PlayClipDebounced(AudioClip clip)
    {

        audioSource.PlayOneShot(clip);

        isUsingAudioSource = true;

        yield return new WaitForSeconds(.3f);

        isUsingAudioSource = false;

    }

    public void TriggerImpactNoise()
    {
        if (!isUsingAudioSource)
        {
            StartCoroutine(PlayClipDebounced(impacts[impactsIndex]));
            impactsIndex = impactsIndex == impacts.Length - 1 ? 0 : impactsIndex + 1;
        }
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
