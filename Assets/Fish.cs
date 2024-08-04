using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        String tag = other.gameObject.tag;
        if (tag == "floor" || tag == "Projectile") {
            Destroy(gameObject);
            GameManager.Instance.HandleFishMurder();
        }
    }
}
