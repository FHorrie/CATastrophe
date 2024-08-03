using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatapultBehavior : MonoBehaviour
{
    [SerializeField] private float _baseStrength = 1.0f;
    [SerializeField] private int _numProjectiles = 5;
    [SerializeField] private Transform _ProjectileSpawn;
    [SerializeField] private GameObject _Projectile;

    private Vector2 _StartMousePos;
    private Vector2 _MousePosDelta = Vector2.zero;
    private bool _IsAiming = false;

    private void FireProjectile()
    {

        GameObject spawnedProjectile = Instantiate(_Projectile, _ProjectileSpawn);
        
        Rigidbody spawnedRigidbody = spawnedProjectile.GetComponent<Rigidbody>();

        if (spawnedRigidbody != null)
        {
            //apply projectile math
            //spawnedRigidbody.AddForce()
        }

        Debug.Log(_MousePosDelta);
        _MousePosDelta = Vector2.zero;
        _IsAiming = false;
    }


    private void OnCatapultTrigger()
    {
        if(!_IsAiming)
        {
            _StartMousePos = Input.mousePosition;
            _IsAiming = true;
        }
        else
            FireProjectile();
    }

    private void Aim()
    {
        if (!_IsAiming)
            return;

        Vector2 currentMousePos = Input.mousePosition;

        _MousePosDelta = currentMousePos - _StartMousePos;

    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();        
    }
}
