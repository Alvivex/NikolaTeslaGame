using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public string currentWeapon;
    public GameObject teslaModel;
    private Animator modelAnimator;
    public GameObject sword;
    public GameObject gun;
    private BoxCollider swordCollider;
    
    void Start()
    {
        modelAnimator = teslaModel.GetComponent<Animator>();
        swordCollider = sword.GetComponent<BoxCollider>();
    }

    void Update()
    {
        SetWeapon();
    }

    public void SetWeapon()
    {
        switch (currentWeapon)
        {
            case "Coil Sword":
                CoilSword();
                break;
            case "Coil Gun":
                CoilGun();
                break;
            case "Coil Grenade":

                break;
            case "Induction drill":

                break;
            default:
                break;
        }
    }

    public void CoilSword()
    {
        modelAnimator.SetBool("ChangeToGun", false);
        modelAnimator.SetBool("ChangeToSword", true);

        Debug.Log("Sword");
    }
    public void CoilGun()
    {
        modelAnimator.SetBool("ChangeToGun", true);
        modelAnimator.SetBool("ChangeToSword", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            modelAnimator.Play("Gun Shot");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hello World");
        }
    }
}
