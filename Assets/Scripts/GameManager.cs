using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public AudioSource ThemeSongSource;
    public static Score score = new Score { banished = 0, wave = 0 };
    public bool started;
    private int money = 250;
    private int wave = 0;
    private int banished = 0;
    private int gateHp = 100;

    private void Awake() {

        if (GameManager.instance != null) {
            Destroy(this);
        } else {
            GameManager.instance = this;
        }
    }

    private void Start() {
        UIManager.instance.SetMoney(money.ToString());
        UIManager.instance.SetWave(1.ToString());
        UIManager.instance.SetBanished(banished.ToString());
        UIManager.instance.SetHealth(gateHp);
    }

    public void AddHp(int amount, int price) {

        if (this.gateHp < 100) {
            this.gateHp += amount;

            if (this.gateHp > 100) {
                this.gateHp = 100;
            }

            AddMoney(-price);
            UIManager.instance.SetHealth(gateHp);
        }
    }

    public void TakeGateDamage(int amount) {
        this.gateHp -= amount;
        UIManager.instance.SetHealth(gateHp);
        SFXManager.Instance.PlayGateDamage();
        if (this.gateHp <= 0) {
            GameOver();
        }
    }

    public void AddMoney(int amount) {
        money += amount;
        UIManager.instance.SetMoney(money.ToString());
    }

    public int GetMoney() {
        return money;
    }

    public void AddBanished() {
        banished += 1;
        UIManager.instance.SetBanished(banished.ToString());
    }

    public void SetWave(int wave) {
        this.wave = wave;
        if (wave == 1)
        {
            StartCoroutine(PlayTheme());
        }
        UIManager.instance.SetWave(wave.ToString());
    }

    public IEnumerator PlayTheme()
    {
        ThemeSongSource.volume = 0.0f;
        ThemeSongSource.loop = true;
        yield return new WaitForSeconds(3f);
        ThemeSongSource.Play();
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

    public int Wave()
    {
        return wave;
    }

    public void Restart() {
        score.wave = 0;
        score.banished = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void GameOver() {
        score.wave = wave;
        score.banished = banished;
        UnityEngine.SceneManagement.SceneManager.LoadScene("end");

    }

}
