using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxScript : MonoBehaviour
{

    public int maxHealth = 100; // The maximum health of the object
    public int currentHealth; // The current health of the object
    public Rigidbody rb; // The rigidbody component of the object
    public Animator animator;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision col)
    {
        // Check if the colliding object has a specific tag or component, such as a "Weapon" tag or a "DamageDealer" component.
        if (col.gameObject.tag=="Weapon")
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
            }
          
        }
    }

}