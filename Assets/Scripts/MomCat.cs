using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class MomCat : MonoBehaviour
{
    [SerializeField] private GameObject _kitten;
    [SerializeField] private int _numKittens;
    [SerializeField] private float _deadTime;

    ProjectileData _projectileData;
    private void OnCatapultTrigger()
    {
        Vector3 _targetDir = Vector3.zero;
        
        for (int i = 0; i < _numKittens; i++)
        {
            GameObject kitten = Instantiate(_kitten,gameObject.transform);
            kitten.transform.SetParent(null,true);

            Rigidbody rigidbody = kitten.GetComponent<Rigidbody>();
            Rigidbody motherBody = gameObject.GetComponent<Rigidbody>();
            if (rigidbody != null) 
            {
                rigidbody.velocity = motherBody.velocity;
            }
        }

        if(_projectileData != null)
        {
            _projectileData.HitPart = true;
        }

        gameObject.SetActive(false);
        Destroy(gameObject, 2.5f);
    }

    private void OnCollisionEnter(Collision other)
    {
        String tag = other.gameObject.tag;
        if (tag == "floor" || tag == "blokjes")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _projectileData = GetComponent<ProjectileData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
