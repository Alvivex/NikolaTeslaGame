using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [HideInInspector]
    public EnemyScript[] enemies;
    public int enemyCount;
    public EnemyScript enemyPrefab;
    public Rect spawnArea;
    public GameObject player;

    void Start() 
    {
        enemies = new EnemyScript[enemyCount];
    }

    void Update()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            if (enemies[i] == null)
            {
                RespawnEnemy(i); 
            }
        }
    }

    void RespawnEnemy(int i)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-27, 27), 1, Random.Range(-27, 27));
        EnemyScript enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity, transform);
        enemy.gameObject.SetActive(true);
        enemy.player = player;
        enemies[i] = enemy;
    }
}

