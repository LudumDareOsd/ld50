using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public static EnemyManager instance;

    private void Awake()
    {
        if (EnemyManager.instance != null) {
            Destroy(this);
        } else {
            EnemyManager.instance = this;
        }

        StartCoroutine(StartWave(1));
    }

    public IEnumerator StartWave(int wave)
    {
        Debug.Log($"starting wave {wave}");        
        SFXManager.Instance.PlayHorn();
        GameManager.instance.SetWave(wave);

        StartCoroutine(SpawnEnemies(wave));

        yield return new WaitForSeconds(30);

        StartCoroutine(StartWave(++wave));
    }


    public IEnumerator SpawnEnemies(int wave)
    {
        while (true)
        {
            var prefab = enemyPrefabs[Random.Range(0, Mathf.Min(enemyPrefabs.Length, wave))];
            var spawn = Instantiate(prefab, transform);
            // var follow = spawn.GetComponent<FollowPath>();
            // var enemy = spawn.GetComponent<Enemy>();
            // spawn.transform.SetParent(transform);

            yield return new WaitForSeconds(5);
        }
    }


}
