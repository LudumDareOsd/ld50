using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager instance;
	private SelectedTower tower;
	private GameObject selectedTower;

	private float gridSize = 0.125f;

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
			selectedTower.transform.position = new Vector3(RoundToNearestGridX(selectedTower.transform.position.x + 0.125f), RoundToNearestGridY(selectedTower.transform.position.y), 0);
		}

		if (selectedTower.GetComponent<BoxCollider2D>().IsTouchingLayers()) {
			selectedTower.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.2f, 0.2f, 1);
		} else {
			selectedTower.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
		}
		


		if (Input.GetMouseButtonDown(0)) {
			if (tower != null) {
				Instantiate(Resources.Load(tower.name) as GameObject, selectedTower.transform.position, selectedTower.transform.rotation);
			}
		}

		if (Input.GetMouseButtonDown(1)) {
			tower = null;
			selectedTower.GetComponent<SpriteRenderer>().sprite = null;
		}
	}

	float RoundToNearestGridX(float pos) {
		float xDiff = pos % gridSize;
		pos -= (xDiff + 0.125f);
		if (xDiff > (gridSize / 2)) {
			pos += gridSize;
		}
		return pos;
	}

	float RoundToNearestGridY(float pos) {
		float xDiff = pos % gridSize;
		pos -= (xDiff);
		if (xDiff > (gridSize / 2)) {
			pos += gridSize;
		}
		return pos;
	}
}
