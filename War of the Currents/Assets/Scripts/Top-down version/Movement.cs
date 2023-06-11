using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    public float moveSpeed;
    public GameObject TeslaModel;
    public Animator modelAnimator;
    public float gravity;

    public bool isSlashing;

    void Start()
    {
        modelAnimator = TeslaModel.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }



    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), -gravity, Input.GetAxis("Vertical"));

        controller.Move(moveDir * moveSpeed * Time.deltaTime);

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        PlayAnimations(movement);
    }

    public void PlayAnimations(Vector3 movement)
    {
        // Play running animation whilst mobile (speed is constant)
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            modelAnimator.SetBool("isRunning", true);
            modelAnimator.SetBool("isIdle", false);
            isSlashing = false;
        }

        // Play slash animation when space is pressed
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            modelAnimator.SetBool("isRunning", false);
            modelAnimator.SetBool("isIdle", false);
            modelAnimator.Play("Melee Swing");
            isSlashing = true;
        }

        // Play idle animation when stationary
        else
        {
            modelAnimator.SetBool("isIdle", true);
            modelAnimator.SetBool("isRunning", false);
            isSlashing = false;
        }

        controller.Move(Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")), 1f) * moveSpeed * Time.deltaTime);
    }
}
