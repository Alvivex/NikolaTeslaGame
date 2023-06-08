using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemyList;
    public int enemyNum;
    
    [HideInInspector]
    public EnemyScript[] enemies;
    public int enemyCount;
    public EnemyScript enemyPrefab;
    public Rect spawnArea;
    public GameObject player;

    void Start() 
    {
        enemies = new EnemyScript[enemyCount];
        enemyList = new List<GameObject>(enemyNum);
    }

    void Update()
    {
        if (enemyNum > 1)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                if (enemies[i] == null)
                {
                    Debug.Log(enemyList[i]);
                    //if (enemyList[i] == null)
                    //{
                    //    RespawnEnemy(i);
                    //}
                }
            }
        }

        else
        {
            Debug.Log("Enemy List is empty");
        }
    }

    void RespawnEnemy(int i)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-27, 27), 1, Random.Range(-27, 27));
        EnemyScript enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity, transform);
        enemy.player = player;
        enemies[i] = enemy;
    }
}

