using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public static EnemyManager instance;

    private int aliveEnemies = 0;

    private void Awake()
    {
        if (EnemyManager.instance != null) {
            Destroy(this);
        } else {
            EnemyManager.instance = this;
        }

        StartWave(1);
    }

    public void StartWave(int wave)
    {
        Debug.Log($"starting wave {wave}");        
        SFXManager.Instance.PlayHorn();
        GameManager.instance.SetWave(wave);

        StartCoroutine(SpawnEnemies(wave));
    }


    public IEnumerator SpawnEnemies(int wave)
    {
        var waves = 3;
        while (waves-- > 0)
        {
            // Always spawn an increasing amount of small demons
            for (int i = 0; i < wave; i++)
            {
                SpawnEnemy(0);
            }

            // Unique mobs per wave
            switch (wave)
            {
                case 1:
                {
                    SpawnEnemy(0);
                break;
                }
                case 2:
                {
                    yield return new WaitForSeconds(1);
                    SpawnEnemy(1);
                break;
                }
                case 3:
                {
                    yield return new WaitForSeconds(.5f);
                    SpawnEnemy(1);
                    yield return new WaitForSeconds(.5f);
                    SpawnEnemy(2);
                break;
                }
                case 4:
                {
                    yield return new WaitForSeconds(.5f);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    yield return new WaitForSeconds(.5f);
                    SpawnEnemy(2);
                    SpawnEnemy(2);
                break;
                }
                case 5:
                {
                    yield return new WaitForSeconds(.5f);
                    SpawnEnemy(2);
                    SpawnEnemy(2);
                    yield return new WaitForSeconds(.5f);
                    SpawnEnemy(3);
                break;
                }
                case 6:
                {
                    yield return new WaitForSeconds(.5f);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    yield return new WaitForSeconds(.5f);
                    SpawnEnemy(3);
                    SpawnEnemy(3);
                break;
                }
                default:
                {
                    for (int i = 0; i < wave; i++)
                    {
                        SpawnEnemy(0);
                        SpawnEnemy(3);
                        SpawnEnemy(Random.Range(0, Mathf.Min(enemyPrefabs.Length, wave)));
                        yield return new WaitForSeconds(.5f);
                    }
                   break;
                }
                    
            }
            yield return new WaitForSeconds(6f);
        }

        while (aliveEnemies > 0)
        {
            yield return new WaitForSeconds(.1f);
        }
        
        yield return new WaitForSeconds(1f);

        StartWave(++wave);
    }

    public void SpawnEnemy(int type)
    {
        aliveEnemies++;
        //Random.Range(0f, 260f);
        var spawnPos = transform.position + new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0f);
        if(type >= 0 && type <= enemyPrefabs.Length)
        {
            var prefab = enemyPrefabs[type];
            var spawn = Instantiate(prefab, spawnPos, transform.rotation);
            spawn.GetComponent<BaseEnemy>().Spawn(GameManager.instance.Wave());
        }
        else
        {
            //var prefab = enemyPrefabs[Random.Range(0, Mathf.Min(enemyPrefabs.Length, wave))];
            var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            var spawn = Instantiate(prefab, spawnPos, transform.rotation);
            spawn.GetComponent<BaseEnemy>().Spawn(GameManager.instance.Wave());
        }
    }

    public void EnemyDied()
    {
        aliveEnemies--;
    }

    public int EnemiesAlive()
    {
        return Mathf.Max(aliveEnemies, 0);
    }
}
