using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public bool started;
	private int money = 200;
	private int wave = 0;
	private int banished = 0;

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
		UIManager.instance.SetWave(1.ToString());
	}
}
