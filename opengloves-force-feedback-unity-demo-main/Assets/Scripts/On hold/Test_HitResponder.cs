using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_HitResponder : MonoBehaviour, IHitResponder
{
    [SerializeField] private bool m_attack;
    [SerializeField] private int m_damage = 10;
    [SerializeField] private Comp_Hitbox _hitbox;

    int IHitResponder.damage { get => m_damage; }


    // Start is called before the first frame update
    void Start()
    {
        _hitbox.HitResponder = this;    
    }

    // Update is called once per frame
    void Update()
    {
        if (m_attack)
        {
            _hitbox.CheckHit();
        }
    }

    bool IHitResponder.CheckHit(HitData data)
    {
        return true;
    }

    void IHitResponder.Response(HitData data)
    {

    }
}
