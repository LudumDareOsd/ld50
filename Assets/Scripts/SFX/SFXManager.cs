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

    private IEnumerator PlayBeingClipDebounced(AudioClip clip, float debounceTime = 0.3f)
    {

        impactAudioSource.PlayOneShot(clip);

        isUsingBeingSource = true;

        yield return new WaitForSeconds(debounceTime);

        isUsingBeingSource = false;

    }

    private IEnumerator PlayImpactClipDebounced(AudioClip clip, float debounceTime = 0.3f)
    {

        impactAudioSource.PlayOneShot(clip);

        isUsingImpactSource = true;

        yield return new WaitForSeconds(debounceTime);

        isUsingImpactSource = false;

    }

    private void TriggerBeingSound(AudioClip[] beingSounds)
    {
        if (!isUsingBeingSource && beingSounds.Length > 0)
        {
            StartCoroutine(PlayBeingClipDebounced(beingSounds[new System.Random().Next(beingSounds.Length)]));
        }
    }

    public void TriggerImpactSound(AudioClip[] impactSounds)
    {
        if (!isUsingImpactSource && impactSounds.Length > 0)
        {
            StartCoroutine(PlayImpactClipDebounced(impactSounds[new System.Random().Next(impactSounds.Length)]));
        }
    }

    public void TriggerHellHogSound() => TriggerBeingSound(hellHogSounds);

    public void TriggerLesserDemonSound() => TriggerBeingSound(lesserDemonSounds);

    public void TriggerHigherDemonSound() => TriggerBeingSound(higherDemonSounds);


    public void TriggerHellPriestSound() => TriggerBeingSound(hellPriestSounds);

    public void TriggerSingleImpactSound() => TriggerImpactSound(singleImpacts);

    public void TriggerSlowSound() => TriggerImpactSound(slowImpacts);

    public void TriggerAoeSound() => TriggerImpactSound(aoeImpacts);


    public void PlayHorn() => defaultSource.PlayOneShot(WaveStartHorn);

    public void PlayGateDamage() => defaultSource.PlayOneShot(GateDamage);



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
