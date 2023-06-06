using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    public float cameraSpeed;
    public float offset;

    void Update()
    {
        FollowPlayer();
        //this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, offset);
    }

    public void FollowPlayer()
    {
        Vector3 aimPos = new Vector3(player.transform.position.x, this.transform.position.y, offset);
        
        transform.position = Vector3.MoveTowards(this.transform.position, aimPos, cameraSpeed * Time.deltaTime);
        this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
    }
}
