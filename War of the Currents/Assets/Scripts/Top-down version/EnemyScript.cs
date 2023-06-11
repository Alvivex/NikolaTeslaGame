using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private CharacterController controller;
    //[HideInInspector]
    public GameObject player;
    public float idleDistance = 5f;
    public float enemySpeed;
    public float gravity;

    public string enemyName;
    public float damage;
    public HPManager playerHP;
    public Animator enemyAnimator;
    public float maxHeight;
    public float health = 100f;

    float timer = 0.0f;
    public float attackInterval;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerHP.enemies.Add(this.gameObject);
    }

    void Update()
    {
        CheckForDestruction();
        MoveTowardsPlayer();
        timer += Time.deltaTime;

        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }
    }

    void MoveTowardsPlayer()
    {
        // Look at player (but never down)
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        // walk close enough to player to deal damage
        if (Vector3.Distance(player.transform.position, transform.position) >= idleDistance)
        {
            Vector3 target = new Vector3(transform.forward.x, -gravity, transform.forward.z);

            controller.Move(target * enemySpeed * Time.deltaTime);

            enemyAnimator.SetBool("isRunning", true);
            enemyAnimator.SetBool("isIdle", false);
            enemyAnimator.SetBool("isAttacking", false);
            Debug.Log("Moving");
        }

        // deal damage if close enough to player (in intervals)
        else
        {
            if ((int)(timer) % (int)(attackInterval) == 0)
            {
                playerHP.TakeDamage(damage);
                enemyAnimator.SetBool("isRunning", false);
                enemyAnimator.SetBool("isIdle", false);
                enemyAnimator.SetBool("isAttacking", true);
            }

            else
            {
                enemyAnimator.SetBool("isRunning", false);
                enemyAnimator.SetBool("isIdle", true);
                enemyAnimator.SetBool("isAttacking", false);
            }
        }

    }

    public void CheckForDestruction()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Total time to destroy was " + timer);
        }
    }
}
