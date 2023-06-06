using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();
    public int enemyNum;
    public GameObject enemyPrefab;

    void Update()
    {
        for (int i = 0; i < enemyNum; i++)
        {
            if (enemyList[i] == null)
            {
                RespawnEnemy(i);
            }
        }
    }

    void RespawnEnemy(int i)
    {
        enemyList[i] = enemyPrefab;

        Vector3 spawnPos = new Vector3(Random.Range(-27, 27), 1, Random.Range(-27, 27));
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}

