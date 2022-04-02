using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
	private SelectedTower tower;

	private void Awake() {

		if (PlayerManager.instance != null) {
			Destroy(this);
		} else {
			PlayerManager.instance = this;
		}

	}


	public void SelectTower(SelectedTower tower) {
		this.tower = tower;
	}

}
