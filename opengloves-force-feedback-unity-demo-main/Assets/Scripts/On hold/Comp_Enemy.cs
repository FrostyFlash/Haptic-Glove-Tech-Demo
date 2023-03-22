using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_Enemy : MonoBehaviour, IHurtResponder
{
    [SerializeField] private Rigidbody m_rbBag;

    private List<Comp_Hurtbox> m_hurtboxes = new List<Comp_Hurtbox>();

    private void Start()
    {
        m_hurtboxes = new List<Comp_Hurtbox>(GetComponentsInChildren<Comp_Hurtbox>());
        foreach (Comp_Hurtbox _hurtbox in m_hurtboxes)
            _hurtbox.HurtResponder = this;
    }

    bool IHurtResponder.CheckHit(HitData data)
    {
        return true;
    }

    void IHurtResponder.Response(HitData data)
    {
        Debug.Log("hurt Response");
    }
}
