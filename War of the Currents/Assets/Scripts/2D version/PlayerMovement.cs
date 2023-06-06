using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float gravityConstant;
    bool isGrounded = true;
    public float jumpSpeed = 0;

    private float force = 0;

    void Update()
    {
        HorizontalMove();
        VerticalMove();
    }

    public void VerticalMove()
    {
        //Check for jump input, and only allow if the player is grounded
        if (Input.GetKeyDown("w"))
        {
            if (isGrounded)
            {
                force = jumpSpeed;
                isGrounded = false;
            }
        }

        // Effect of gravity
        if (force >= -100)
        {
            force -= gravityConstant * Time.deltaTime;
        }

        // Execution on character controller
        controller.Move(new Vector3(0, force, 0) * Time.deltaTime);
    }

    public void HorizontalMove()
    {
        // Move left and right
        if (Input.GetKey("d"))
        {
            controller.Move(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        }
        else if (Input.GetKey("a"))
        {
            controller.Move(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit collision)
    {
        // Check to see if the player is on the ground so they can jump
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Hit Ground");
            isGrounded = true;
        }
    }
}
