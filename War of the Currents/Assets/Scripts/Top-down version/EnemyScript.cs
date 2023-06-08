using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private CharacterController controller;
    [HideInInspector]
    public GameObject player;
    public float idleDistance = 5f;
    public float enemySpeed;
    public float gravity;

    public string enemyName;

    public HPManager playerHP;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerHP.enemies.Add(this.gameObject);
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        if (Vector3.Distance(player.transform.position, transform.position) <= idleDistance)
        {

            Vector3 target = new Vector3(transform.forward.x, -gravity, transform.forward.z);
            controller.Move(target * enemySpeed * Time.deltaTime);
        }
    }
}
