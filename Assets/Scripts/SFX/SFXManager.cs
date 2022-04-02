using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioSource audioSource;

    private bool isUsingAudioSource;

    public AudioClip[] impacts;

    public AudioClip[] smallCreatureScreams;

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
        if (!isUsingAudioSource && impacts.Length > 0)
        {
            StartCoroutine(PlayClipDebounced(impacts[new System.Random().Next(impacts.Length)]));
        }
    }

    public void TriggerSmallCreatureScream()
    {
        if (!isUsingAudioSource && smallCreatureScreams.Length > 0)
        {
            StartCoroutine(PlayClipDebounced(smallCreatureScreams[new System.Random().Next(smallCreatureScreams.Length)]));
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
