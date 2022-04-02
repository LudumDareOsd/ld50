using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
	private SelectedTower tower;
	private GameObject selectedTower;

	private void Awake() {

		if (PlayerManager.instance != null) {
			Destroy(this);
		} else {
			PlayerManager.instance = this;
			selectedTower = GameObject.Find("SelectedTower");
		}
	}

	public void SelectTower(SelectedTower tower) {
		this.tower = tower;
		selectedTower.GetComponent<SpriteRenderer>().sprite = tower.sprite;
	}

	public void Update() {

		Vector3 mousePos = Input.mousePosition;
		{
			selectedTower.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
			selectedTower.transform.position = new Vector3(selectedTower.transform.position.x, selectedTower.transform.position.y, 0);
		}

	}
}
