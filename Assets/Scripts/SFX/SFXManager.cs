using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioSource defaultSource;

    public AudioSource beingAudioSource;

    public AudioSource impactAudioSource;

    private bool isUsingBeingSource;

    private bool isUsingImpactSource;

    public AudioClip[] singleImpacts;

    public AudioClip[] slowImpacts;

    public AudioClip[] aoeImpacts;

    public AudioClip[] hellHogSounds;

    public AudioClip[] lesserDemonSounds;

    public AudioClip[] higherDemonSounds;

    public AudioClip[] hellPriestSounds;

    public AudioClip WaveStartHorn;

    public AudioClip GateDamage;

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

    private IEnumerator PlayBeingClipDebounced(AudioClip clip, float volume, float debounceTime = 0.3f)
    {

        impactAudioSource.PlayOneShot(clip, volume);

        isUsingBeingSource = true;

        yield return new WaitForSeconds(debounceTime);

        isUsingBeingSource = false;

    }

    private IEnumerator PlayImpactClipDebounced(AudioClip clip, float volume, float debounceTime = 0.3f)
    {

        impactAudioSource.PlayOneShot(clip, volume);

        isUsingImpactSource = true;

        yield return new WaitForSeconds(debounceTime);

        isUsingImpactSource = false;

    }

    private void TriggerBeingSound(AudioClip[] beingSounds, float volume)
    {
        if (!isUsingBeingSource && beingSounds.Length > 0)
        {
            StartCoroutine(PlayBeingClipDebounced(beingSounds[new System.Random().Next(beingSounds.Length)], volume));
        }
    }

    public void TriggerImpactSound(AudioClip[] impactSounds, float volume)
    {
        if (!isUsingImpactSource && impactSounds.Length > 0)
        {
            StartCoroutine(PlayImpactClipDebounced(impactSounds[new System.Random().Next(impactSounds.Length)], volume));
        }
    }

    public void TriggerHellHogSound(float volume = 1f) => TriggerBeingSound(hellHogSounds, volume);

    public void TriggerLesserDemonSound(float volume = 1f) => TriggerBeingSound(lesserDemonSounds, volume);

    public void TriggerHigherDemonSound(float volume = 1f) => TriggerBeingSound(higherDemonSounds, volume);


    public void TriggerHellPriestSound(float volume = 1f) => TriggerBeingSound(hellPriestSounds, volume);

    public void TriggerSingleImpactSound(float volume = 1f) => TriggerImpactSound(singleImpacts, volume);

    public void TriggerSlowSound(float volume = 1f) => TriggerImpactSound(slowImpacts, volume);

    public void TriggerAoeSound(float volume = 1f) => TriggerImpactSound(aoeImpacts, volume);


    public void PlayHorn(float volume = 1f) => defaultSource.PlayOneShot(WaveStartHorn, volume);

    public void PlayGateDamage(float volume = 1f) => defaultSource.PlayOneShot(GateDamage, volume);



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
