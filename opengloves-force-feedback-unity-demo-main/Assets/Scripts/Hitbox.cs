using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float fDamage = 20;
    public Vector3 knockBack = new Vector3(0,5,15);
    
    
    private void OnTriggerEnter(Collider other)
    {
        Hurtbox h = other.GetComponent<Hurtbox>();

        if(h!= null)
        {
            
        }
    }
}
