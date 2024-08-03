using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrainBehavior : MonoBehaviour
{
    [SerializeField] private float _trainSpeedMultiplier = 1.0f;
    [SerializeField] private InputActionReference _TrainMovementAction;

    private float _currentTrainSpeed = 0.0f;
    private float _currentRotationAngle = 0.0f;
    private float _currentInputValue = 0.0f;

    private bool _pressed = false;

    private void OnTrainMovement()
    {
        _pressed = !_pressed;
        _currentInputValue = _TrainMovementAction.action.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_pressed)
        {
            _currentTrainSpeed = _trainSpeedMultiplier * _currentInputValue;
        }
        else
        {
            _currentTrainSpeed = 0;
        }

        gameObject.transform.Rotate(Vector3.up, -_currentRotationAngle);

        _currentRotationAngle += _currentTrainSpeed * Time.deltaTime;

        gameObject.transform.Rotate(Vector3.up, _currentRotationAngle);

    }
}
