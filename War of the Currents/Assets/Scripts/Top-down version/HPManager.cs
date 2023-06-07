using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    private float health;
    public List<GameObject> enemies = new List<GameObject>();

    public float colliderDistance;
    public List<EnemyManager> enemyManagers;
    public float enemyDamage;
    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20f);
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(10f);
        }

        CheckForDamage();
    }

    public void TakeDamage(float damage)
    { 
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
    }

    public void Heal(float healingAmount)
    {
        health += healingAmount;
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.fillAmount = health / maxHealth;
    }

    public void CheckForDamage()
    {
        foreach (EnemyManager manager in enemyManagers) foreach (EnemyScript enemy in manager.enemies)
        {
            Debug.Log(enemy);
            if (Vector3.Distance(enemy.transform.position, transform.position) <= colliderDistance)
            {
                TakeDamage(enemyDamage * Time.deltaTime);
            }
        }
    }
}
