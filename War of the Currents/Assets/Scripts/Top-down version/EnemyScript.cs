using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private CharacterController controller;
    public GameObject player;
    public float idleDistance = 5f;
    public float enemySpeed;

    public string enemyName;

    public HPManager playerHP;
    //public EnemyManager enemyManager;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerHP.enemies.Add(this.gameObject);
        //enemyManager.enemyList.Add(this.gameObject);
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        transform.LookAt(player.transform);

        if (Vector3.Distance(player.transform.position, transform.position) >= idleDistance)
        {

            Vector3 target = new Vector3(transform.forward.x, 0, transform.forward.z);
            controller.Move(target * enemySpeed * Time.deltaTime);
        }
    }
}
