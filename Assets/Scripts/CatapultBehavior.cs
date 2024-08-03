using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Services.Analytics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatapultBehavior : MonoBehaviour
{
    [SerializeField] private float _baseStrength = 1.0f;
    [SerializeField] private float _mouseSense = 0.3f;
    [SerializeField] private int _numProjectiles = 5;
    [SerializeField] private Transform _ProjectileSpawn;
    [SerializeField] private GameObject _Projectile;

    private Vector3 _launchVelocity = Vector3.zero;
    private Vector2 _StartMousePos;
    private Vector2 _MousePosDelta = Vector2.zero;

    private bool _IsCharging = false;
    private float _hAngle = 0.0f;
    private float _vAngle = 0.0f;


    private void FireProjectile()
    {
        GameObject spawnedProjectile = Instantiate(_Projectile, _ProjectileSpawn);
        
        Rigidbody spawnedRigidbody = spawnedProjectile.GetComponent<Rigidbody>();

        if (spawnedRigidbody != null)
        {
            _launchVelocity.x = _baseStrength * Mathf.Cos(_hAngle) * Mathf.Cos(_vAngle);
            _launchVelocity.y = _baseStrength * Mathf.Sin(_hAngle);
            _launchVelocity.z = _baseStrength * Mathf.Cos(_hAngle) * Mathf.Sin(_vAngle); 
            //spawnedRigidbody.AddForce()
        }

        Debug.Log(_MousePosDelta);
        _MousePosDelta = Vector2.zero;
        _IsCharging = false;
    }


    private void OnCatapultTrigger()
    {
        if(!_IsCharging)
        {
            _StartMousePos = Input.mousePosition;
            _IsCharging = true;
        }
        else
            FireProjectile();
    }

    private void Aim()
    {
        if (_IsCharging)
        {
            Vector2 currentMousePos = Input.mousePosition;
            _MousePosDelta = currentMousePos - _StartMousePos;

            return;
        }

        Vector2 relativeMousePos = Mouse.current.delta.ReadValue() * _mouseSense;

        _hAngle += relativeMousePos.x;
        _vAngle += relativeMousePos.y;

        _hAngle = Mathf.Clamp(_hAngle, -45f, 45f);
        _vAngle = Mathf.Clamp(_vAngle, -75f, 15f);
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
