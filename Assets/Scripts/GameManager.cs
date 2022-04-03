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
		UIManager.instance.SetWave(1.ToString());
	}

	public void GameOver() {
		var score = new Score();
		score.banished = banished;
		score.wave = wave;


	}
}
