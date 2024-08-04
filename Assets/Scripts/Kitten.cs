using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitten : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        String tag = other.gameObject.tag;
        if (tag == "floor" || tag == "blokjes")
        {
            Destroy(gameObject, 2.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
