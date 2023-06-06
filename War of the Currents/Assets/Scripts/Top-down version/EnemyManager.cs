using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemyList;
    public int enemyNum;
    public GameObject enemyPrefab;

    void Start()
    {
        enemyList = new List<GameObject>(enemyNum);
    }

    void Update()
    {
        if (enemyNum > 1)
        {
            for (int i = 0; i < enemyNum; i++)
            {
                Debug.Log(enemyList[i]);
                //if (enemyList[i] == null)
                //{
                //    RespawnEnemy(i);
                //}
            }
        }

        else
        {
            Debug.Log("Enemy List is empty");
        }
    }

    void RespawnEnemy(int i)
    {
        enemyList[i] = enemyPrefab;

        Vector3 spawnPos = new Vector3(Random.Range(-27, 27), 1, Random.Range(-27, 27));
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}

