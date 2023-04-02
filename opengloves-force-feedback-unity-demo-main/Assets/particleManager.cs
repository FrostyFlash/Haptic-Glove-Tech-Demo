using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class particleManager : MonoBehaviour
{
    public float lifeTime = 1.0f;
    // Update is called once per frame

    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
