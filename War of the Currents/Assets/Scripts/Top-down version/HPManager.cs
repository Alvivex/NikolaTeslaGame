using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    private float health;
    public float colliderDistance;
    public List<EnemyManager> enemyManagers;
    public float enemyDamage;
    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        CheckForDamage();

        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
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
            if (enemy == null) continue;
            if (Vector3.Distance(enemy.transform.position, transform.position) <= colliderDistance)
            {
                TakeDamage(enemyDamage * Time.deltaTime);
            }
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit collider)
    {
        switch (collider.gameObject.tag)
        {
            // Manage health capsules
            case "XP":
                Heal(20f);
                Destroy(collider.gameObject);
                break;
            default:
                break;
        }
    }
}
