using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	public void Awake() {
		if (UIManager.instance != null) {
			Destroy(this);
		} else {
			UIManager.instance = this;
		}
	}

}
