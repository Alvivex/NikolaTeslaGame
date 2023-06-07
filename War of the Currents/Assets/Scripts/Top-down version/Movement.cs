using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    public float moveSpeed;

    public void Start() 
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        controller.Move(
            Vector3.ClampMagnitude(new Vector3(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")
            ), 1f) * moveSpeed * Time.deltaTime
        );
    }
}
