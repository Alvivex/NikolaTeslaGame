using UnityEngine;
using Random = UnityEngine.Random;

namespace System.Runtime.CompilerServices {internal static class IsExternalInit {}}

public class EnemyManager : MonoBehaviour
{
    [HideInInspector]
    public EnemyScript[] enemies;
    
    public int enemyCount;
    public EnemyType[] enemyPrefabs;
    public Rect spawnArea;
    public GameObject player;

    private float[] cumulativeWeights;
    private float totalWeight;

    [System.Serializable]
    public struct EnemyType {
        public float weight; 
        public EnemyScript prefab;
    }

    void Start() 
    {
        enemies = new EnemyScript[enemyCount];
        cumulativeWeights = new float[enemyPrefabs.Length];
        totalWeight = 0;
        for (int i=0; i<cumulativeWeights.Length; i++) {
            totalWeight += enemyPrefabs[i].weight;
            cumulativeWeights[i] = totalWeight;
        }
    }

    private EnemyScript GetEnemy() {
        float target = Random.Range(0f, totalWeight);
        for (int i=0; i<enemyPrefabs.Length; i++) {
            if (cumulativeWeights[i] >= target) return enemyPrefabs[i].prefab;
        }
        return null;
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
        EnemyScript enemy = Instantiate(GetEnemy(), spawnPos, Quaternion.identity, transform);
        enemy.gameObject.SetActive(true);
        enemy.player = player;
        enemies[i] = enemy;
    }
}

