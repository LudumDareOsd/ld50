using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] enemies;

    public static EnemyManager instance;

	private void Awake()
    {
		if (EnemyManager.instance != null) {
			Destroy(this);
		} else {
			EnemyManager.instance = this;
		}
	}


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy() {

    }
}
