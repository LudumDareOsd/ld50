using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioSource defaultSource;

    public AudioSource beingAudioSource;

    public AudioSource singleImpactAudioSource;

    public AudioSource aoeImpactAudioSource;

    public AudioSource slowImpactAudioSource;

    private bool isUsingBeingSource;

    private bool isUsingSingleImpactSource;

    private bool isUsingImpactAoeSource;

    private bool isUsingSlowImpactSource;

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

    private static float NextFloat(float min, float max)
    {
        return (float)(new System.Random().NextDouble() * (max - min) + min);
    }

    private IEnumerator PlayBeingClipDebounced(AudioClip clip, float volume, float debounceTime = 0.3f)
    {

        beingAudioSource.PlayOneShot(clip, volume);

        isUsingBeingSource = true;

        yield return new WaitForSeconds(debounceTime);

        isUsingBeingSource = false;

    }

    private IEnumerator PlaySingleImpactClipDebounced(float volume, float debounceTime = 0.3f)
    {
        singleImpactAudioSource.pitch = NextFloat(0.5f, 1.5f);
        singleImpactAudioSource.PlayOneShot(singleImpacts[new System.Random().Next(singleImpacts.Length)], volume);

        isUsingSingleImpactSource = true;

        yield return new WaitForSeconds(debounceTime);

        isUsingSingleImpactSource = false;

    }

    private IEnumerator PlayAoeImpactClipDebounced(float volume, float debounceTime = 0.3f)
    {
        aoeImpactAudioSource.pitch = NextFloat(0.5f, 1.5f);
        aoeImpactAudioSource.PlayOneShot(aoeImpacts[new System.Random().Next(aoeImpacts.Length)], volume);

        isUsingImpactAoeSource = true;

        yield return new WaitForSeconds(debounceTime);

        isUsingImpactAoeSource = false;

    }

    private IEnumerator PlaySlowImpactClipDebounced(float volume, float debounceTime = 0.3f)
    {
        slowImpactAudioSource.pitch = NextFloat(0.5f, 1.5f);
        slowImpactAudioSource.PlayOneShot(slowImpacts[new System.Random().Next(slowImpacts.Length)], volume);

        isUsingSlowImpactSource = true;

        yield return new WaitForSeconds(debounceTime);

        isUsingSlowImpactSource = false;

    }

    private void TriggerBeingSound(AudioClip[] beingSounds, float volume)
    {
        if (!isUsingBeingSource && beingSounds.Length > 0)
        {
            StartCoroutine(PlayBeingClipDebounced(beingSounds[new System.Random().Next(beingSounds.Length)], volume));
        }
    }


    public void TriggerHellHogSound(float volume = 1f) => TriggerBeingSound(hellHogSounds, volume);

    public void TriggerLesserDemonSound(float volume = 1f) => TriggerBeingSound(lesserDemonSounds, volume);

    public void TriggerHigherDemonSound(float volume = 1f) => TriggerBeingSound(higherDemonSounds, volume);


    public void TriggerHellPriestSound(float volume = 1f) => TriggerBeingSound(hellPriestSounds, volume);

    public void TriggerSingleImpactSound(float volume = 1f)
    {
        if (!isUsingSingleImpactSource && singleImpacts.Length > 0)
        {
            StartCoroutine(PlaySingleImpactClipDebounced(volume));
        }
    }

    public void TriggerSlowSound(float volume = 1f)
    {
        if (!isUsingSlowImpactSource && slowImpacts.Length > 0)
        {
            StartCoroutine(PlaySlowImpactClipDebounced(volume));
        }
    }

    public void TriggerAoeSound(float volume = 1f)
    {
        if (!isUsingImpactAoeSource && aoeImpacts.Length > 0)
        {
            StartCoroutine(PlayAoeImpactClipDebounced(volume));

        }
    }


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
