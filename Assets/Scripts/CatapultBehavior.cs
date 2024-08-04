using System;
using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Tracing;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class CatapultBehavior : MonoBehaviour
    {   
        [SerializeField] private float _baseStrength = 1.0f;
        [SerializeField] private float _mouseSense = 0.3f;
        [SerializeField] private int _numProjectiles = 5;
        [SerializeField] private float _maxPullForce = 100.0f;
        [SerializeField] private Transform _ProjectileSpawn;
        [SerializeField] private GameObject _Projectile;

        [Header("Catapult Blend")] [SerializeField]
        private Animator _CatapultAnimator;
        


        private float _CatapultCharge = 0.0f;
        private float _CatapultChargeTimer = 0.0f;
        private bool _CatapultChargeDirection = true;


    
        private Vector2 _StartMousePos;
        private Vector2 _MousePosDelta = Vector2.zero;

        private bool _IsCharging = false;
        private float _hAngle = 0.0f;
        private float _vAngle = 0.0f;


        private void FireProjectile()
        {
            GameObject spawnedProjectile = Instantiate(_Projectile, _ProjectileSpawn);
            spawnedProjectile.transform.SetParent(null, true);


            Rigidbody spawnedRigidbody = spawnedProjectile.GetComponent<Rigidbody>();

            if (spawnedRigidbody != null)
            {
                spawnedRigidbody.AddForce(gameObject.transform.forward * (-1*_MousePosDelta.y) * _baseStrength);
            }

            //Debug.Log(_MousePosDelta);
            _MousePosDelta = Vector2.zero;
            _IsCharging = false;
            _CatapultCharge = 0.0f;
            _CatapultChargeTimer = 0.0f;
            _CatapultChargeDirection = true;
            _CatapultAnimator.SetFloat("Pull Force", 0.0f);

            Debug.Log(_hAngle);
            Debug.Log(_vAngle);
        }


        private void OnCatapultTrigger()
        {
            if(!_IsCharging)
            {
                _StartMousePos = Input.mousePosition;
                _IsCharging = true;
                _CatapultAnimator.SetTrigger("Start Pull");
                Debug.Log("Started Pulling");
            }
            else {
                //Set "EndPull" trigger in animator
                _CatapultAnimator.SetTrigger("Release");
                FireProjectile();
            }

        }

        private void Aim()
        {
            if (_IsCharging)
            {
                Vector2 currentMousePos = Input.mousePosition;
                _MousePosDelta = currentMousePos - _StartMousePos;
                
                //make the current charge go up and down while holding 
                if (_CatapultChargeDirection)
                {
                    _CatapultCharge += Time.deltaTime * _maxPullForce / 2;
                    if (_CatapultCharge >= _maxPullForce)
                    {
                        _CatapultChargeDirection = false;
                    }
                }
                else
                {
                    _CatapultCharge -= Time.deltaTime * _maxPullForce / 2;
                    if (_CatapultCharge <= 0.1) //0.1 cuz animation is weird at 0
                    {
                        _CatapultChargeDirection = true;
                    }
                }
                
                
                //should be between 0 and 1
                float animationValue = _CatapultCharge / _maxPullForce;
                Debug.Log("Animation Value: " + animationValue);
                _CatapultAnimator.SetFloat("Pull Force", animationValue);
                

                return;
            }

            Vector2 relativeMousePos = Mouse.current.delta.ReadValue() * _mouseSense;

            float prevHAngle = _hAngle;
            float prevVAngle = _vAngle;

            gameObject.transform.Rotate(Vector3.right, -_vAngle);
            gameObject.transform.Rotate(Vector3.up, _hAngle);

            _hAngle += relativeMousePos.x;
            _vAngle += relativeMousePos.y;

            _hAngle = Mathf.Clamp(_hAngle, -45f, 45f);
            _vAngle = Mathf.Clamp(_vAngle, -55f, 15f);

            gameObject.transform.Rotate(Vector3.up, -_hAngle);
            gameObject.transform.Rotate(Vector3.right, _vAngle);

        }

        // Start is called before the first frame update
        void Start()
        {
            if (_CatapultAnimator == null)
            {
                Debug.LogError("Animator is null");
            }
        
        }

        // Update is called once per frame
        void Update()
        {
            Aim();       
            // test += Time.deltaTime;
            // _CatapultAnimator.SetFloat("Pull Force", (Mathf.Sin(test) + 1) / 2);

        }
    }
