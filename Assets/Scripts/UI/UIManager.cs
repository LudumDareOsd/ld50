using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	private TextMeshProUGUI banished;
	private TextMeshProUGUI money;
	private TextMeshProUGUI wave;
	private Image healthBar;

	public void Awake() {
		if (UIManager.instance != null) {
			Destroy(this);
		} else {
			UIManager.instance = this;
			banished = GameObject.Find("Banished").GetComponent<TextMeshProUGUI>();
			money = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
			wave = GameObject.Find("Wave").GetComponent<TextMeshProUGUI>();
			healthBar = GameObject.Find("Healthbar").GetComponent<Image>();


			banished.text = "0";
			money.text = "0";
			wave.text = "1";
		}
	}

	public void SetBanished(string banished) {
		this.banished.text = banished;
	}

	public void SetMoney(string money) {
		this.money.text = money;
	}

	public void SetWave(string wave) {
		this.wave.text = wave;
	}

	public void SetHealth(int hp) {
		float fraction = hp / 100f;
		this.healthBar.rectTransform.sizeDelta = new Vector2(185.7f * fraction, this.healthBar.rectTransform.sizeDelta.y);
	}


}
