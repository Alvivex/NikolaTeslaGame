using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float cameraHeight;
    public float followSpeed;

    void Update()
    {
        Vector3 aimPos = new Vector3(player.transform.position.x, cameraHeight, player.transform.position.z + offset);
        transform.position = Vector3.MoveTowards(transform.position, aimPos, followSpeed * Time.deltaTime);
    }
}
