using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	private TextMeshProUGUI banished;
	private TextMeshProUGUI money;
	private TextMeshProUGUI wave;

	public void Awake() {
		if (UIManager.instance != null) {
			Destroy(this);
		} else {
			UIManager.instance = this;
			banished = GameObject.Find("Banished").GetComponent<TextMeshProUGUI>();
			money = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
			wave = GameObject.Find("Wave").GetComponent<TextMeshProUGUI>();

			banished.text = "0";
			money.text = "0";
			wave.text = "1";
		}
	}



}
