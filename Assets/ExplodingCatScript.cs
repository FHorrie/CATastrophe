using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingCatScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _explosionRadius = 5.0f;
    [SerializeField] private float _explosionForce = 100.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        String tag = other.gameObject.tag;
        if (tag == "floor" || tag == "blokjes") {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Kboom();
            Destroy(gameObject);
        }
    }

    public void Kboom() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
        
    }
}
