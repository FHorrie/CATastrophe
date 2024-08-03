using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileData : MonoBehaviour
{
    private bool m_HitPart = false;
    private const string BLOCKTAG = "blokjes";

    public bool HitPart
    { 
        get { return m_HitPart; }
    }

    private void Start()
    {
        //Make sure "Projectile" tag :)
        tag = "Projectile";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!m_HitPart && collision.gameObject.tag == BLOCKTAG)
            m_HitPart = true;
    }
}
