using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    EnemyScript enemyScript;
    public Animator playerAnim;
    public float damage;

    public float flashTime;
    public Color originalColor;
    private SkinnedMeshRenderer renderer;

    void FlashRed()
    {
        renderer.material.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        renderer.material.color = originalColor;
    }

    public void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case ("Enemy"):
                if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Melee Swing"))
                {
                    enemyScript = collider.GetComponent<EnemyScript>();
                    renderer = collider.GetComponent<SkinnedMeshRenderer>();

                    FlashRed();

                    enemyScript.health -= damage;
                    Debug.Log(enemyScript.health);

                }
                break;

            default:
                renderer.material.color = originalColor;
                break;
        }
    }
}
