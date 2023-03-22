using System.Collections;

using UnityEngine;

public class PlayerHurtbox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy collision");
        }
    }
}
