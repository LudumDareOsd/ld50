using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerUI : MonoBehaviour, IPointerClickHandler
{
	public GameObject tower;

	public void OnPointerClick(PointerEventData eventData) {

		var selectTower = new SelectedTower();
		selectTower.name = tower.name;
		selectTower.sprite = tower.GetComponentInChildren<SpriteRenderer>().sprite;
		
		PlayerManager.instance.SelectTower(selectTower);

	}
}
