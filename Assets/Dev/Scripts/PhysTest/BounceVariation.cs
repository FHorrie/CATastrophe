using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceVariation : MonoBehaviour
{
    private Rigidbody m_RigidBody;

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_RigidBody.AddForce(Random.insideUnitCircle.x * 10, 0, Random.insideUnitCircle.y * 10, ForceMode.Impulse);
    }
}
