using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceVariation : MonoBehaviour
{
    private Rigidbody m_RigidBody;
    private float m_BounceForce = 1.2f;

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //m_RigidBody.AddForce(0, -15, 0, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_RigidBody.AddRelativeForce(Random.insideUnitCircle.x * m_BounceForce, 0, Random.insideUnitCircle.y * m_BounceForce, ForceMode.Impulse);
    }
}