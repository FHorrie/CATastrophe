using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKillVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float m_MininumVelocity = 0.1f;

    private Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the velocity is less than threshold, destroy self
        if(rb.velocity.magnitude < m_MininumVelocity)
            Destroy(gameObject);
    }
}
