using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public List<GameObject> enemies = new List<GameObject>();

    public float colliderDistance;
    public EnemyManager enemyManager;
    public float enemyDamage;

    void Update()
    {
        if (healthAmount <= 0)
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
        healthAmount -= damage * Time.deltaTime;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    public void CheckForDamage()
    {
        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) <= colliderDistance)
            {
                TakeDamage(enemyDamage);
            }
        }
    }
}
