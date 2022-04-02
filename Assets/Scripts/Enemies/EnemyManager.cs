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

        StartCoroutine(SpawnEnemies());
	}


    public IEnumerator SpawnEnemies()
    {
        // SFXManager.Instance.PlayHorn();

        while(true)
        {
            var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            var spawn = Instantiate(prefab, transform);
            // var follow = spawn.GetComponent<FollowPath>();
            // var enemy = spawn.GetComponent<Enemy>();
            // spawn.transform.SetParent(transform);

            yield return new WaitForSeconds(5);
        }
    }


}
