using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{

    public int maxHealth = 100; // The maximum health of the object
    public int currentHealth; // The current health of the object
    public bool isDead = false;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider col)
    {
        // Check if the colliding object has a specific tag or component, such as a "Weapon" tag or a "DamageDealer" component.
        if (col.gameObject.tag == "Enemy")
        {
            HitboxScript hitbox = col.gameObject.GetComponent<HitboxScript>();

            if (hitbox != null)
            {
                currentHealth -= hitbox.damage;
                Debug.Log("Damage taken");

                if (currentHealth <= 0)
                {
                    // Execute code to destroy or disable the object
                    isDead = true;
                }
            }

        }
    }

}