using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Themesong : MonoBehaviour
{
    public AudioSource ThemeSongSource;

    private void Awake()
    {
        DontDestroyOnLoad(ThemeSongSource);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayTheme()
    {
        StartCoroutine(PlayThemeDelayed());
    }

    private IEnumerator PlayThemeDelayed()
    {
        ThemeSongSource.volume = 0.0f;
        ThemeSongSource.loop = true;

        if (!ThemeSongSource.isPlaying)
        {
            yield return new WaitForSeconds(3f);
            ThemeSongSource.Play();    
        }

        StartCoroutine(ToneInMusic(0.1f));
    }

    private IEnumerator ToneInMusic(float currentVolume)
    {
        ThemeSongSource.volume = currentVolume;
        yield return new WaitForSeconds(0.5f);
        if (currentVolume < 1.0f)
        {
            StartCoroutine(ToneInMusic(currentVolume + 0.1f));
        }
    }

    public void ToneOutMusic()
    {
        StartCoroutine(LowerMusic(ThemeSongSource.volume, 0.5f));
    }

    private IEnumerator LowerMusic(float currentVolume, float threshHold)
    {
        ThemeSongSource.volume = currentVolume;
        yield return new WaitForSeconds(0.5f);
        if (currentVolume > threshHold)
        {
            StartCoroutine(LowerMusic(currentVolume - 0.1f, threshHold));
        }
    }

}
