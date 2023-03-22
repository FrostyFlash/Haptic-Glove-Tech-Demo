using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public int damage = 10;
    public int hitPoints = 100; // The amount of hit points the object has

    void OnCollisionEnter(Collision col)
    {
        // Code to be executed when the hitbox collides with another object
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            // Execute code to destroy or disable the object
        }
    }

}
