using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceVariation : MonoBehaviour
{
    private Rigidbody m_RigidBody;
    private float m_BounceForce = 1.2f;

    private int m_Mass = 10;
    private int m_LaunchForce = 10;

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        if (m_RigidBody == null)
            return;

        m_RigidBody.mass = m_Mass;
    }

    private void Start()
    {
        m_RigidBody.AddRelativeForce(0, m_LaunchForce * m_Mass, 2 * m_LaunchForce * m_Mass, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_RigidBody.AddRelativeForce(Random.insideUnitCircle.x * m_BounceForce, 0, Random.insideUnitCircle.y * m_BounceForce, ForceMode.Impulse);
    }
}