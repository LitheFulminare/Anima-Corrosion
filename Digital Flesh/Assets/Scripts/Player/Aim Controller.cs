using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimController : MonoBehaviour
{
    [SerializeField] private InputActionReference _aim;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _defaultCameraPosition;
    [SerializeField] private Transform _aimingCameraPosition;

    private bool _isAiming = false;

    private void OnEnable()
    {
        _aim.action.started += Aim;
    }

    private void OnDisable()
    {
        _aim.action.started -= Aim;
    }

    // changes camera position when RMB is pressed
    private void Aim(InputAction.CallbackContext context)
    {
        if (_isAiming)
        {
            _camera.transform.position = _defaultCameraPosition.position;
            _camera.transform.rotation = _defaultCameraPosition.rotation;
            _isAiming = false;
        }
        else
        {
            _camera.transform.position = _aimingCameraPosition.position;
            _camera.transform.rotation = _aimingCameraPosition.rotation;
            _isAiming = true;
        }
    }
}
