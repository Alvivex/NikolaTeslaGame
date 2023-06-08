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
        CheckForDamage();
        if (healthAmount <= 0)
        {
            Debug.Log("Game Over");
        }
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
