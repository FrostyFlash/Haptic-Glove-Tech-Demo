using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxScript : MonoBehaviour
{

    public int maxHealth = 100; // The maximum health of the object
    public int currentHealth; // The current health of the object
    public Rigidbody rb; // The rigidbody component of the object
    public Animator animator;
    public float invulnerabilityTime = 1.0f; // The duration of invulnerability after being hit
    private bool isInvulnerable = false; // Whether the object is currently invulnerable
    private float invulnerabilityTimer = 0.0f; // The remaining time of invulnerability

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isInvulnerable)
        {
            // Decrease the remaining invulnerability time
            invulnerabilityTimer -= Time.deltaTime;

            if (invulnerabilityTimer <= 0.0f)
            {
                // End the invulnerability period
                isInvulnerable = false;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!isInvulnerable && col.gameObject.tag == "Weapon")
        {
            HitboxScript hitbox = col.gameObject.GetComponent<HitboxScript>();

            if (hitbox != null)
            {
                currentHealth -= hitbox.damage;
                Debug.Log("Damage taken");

                if (currentHealth <= 0)
                {
                    // Execute code to destroy or disable the object
                    rb.constraints = RigidbodyConstraints.FreezeAll; // Freeze the rigidbody
                    animator.SetBool("isDead", true);
                }
                else
                {
                    // Start the invulnerability period
                    isInvulnerable = true;
                    invulnerabilityTimer = invulnerabilityTime;
                }
            }
        }
    }

}

