using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimController : MonoBehaviour
{
    [SerializeField] private InputActionReference _aim;    
    [SerializeField] private Transform _defaultCameraPosition;
    [SerializeField] private Transform _aimingCameraPosition;
    [SerializeField] private GameObject _characterSprite;

    private bool _isAiming = false;
    private Camera _camera;
    private MovementController _movementController;

    private void OnEnable()
    {
        _aim.action.started += Aim;
    }

    private void OnDisable()
    {
        _aim.action.started -= Aim;
    }

    private void Start()
    {
        _camera = Camera.main;
        _movementController = GetComponent<MovementController>();
    }

    private void Update()
    {
        if (_isAiming) LookAtMouse();
    }

    // changes camera position when RMB is pressed
    private void Aim(InputAction.CallbackContext context)
    {
        if (_isAiming)
        {
            _camera.transform.SetPositionAndRotation(_defaultCameraPosition.position, _defaultCameraPosition.rotation);
            _characterSprite.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            _isAiming = false;
        }
        else
        {
            _camera.transform.SetPositionAndRotation(_aimingCameraPosition.position, _aimingCameraPosition.rotation);
            _isAiming = true;
        }

        // slows player down when aiming
        if (_movementController != null)
        {
            _movementController.SlowOnAim(_isAiming);
        }
    }

    // makes the character look to the crosshair position when aiming
    private void LookAtMouse()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.transform.position.y - transform.position.y));

        // calculates the angle to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angleRad = Mathf.Atan2(-direction.x, direction.z); // Using x and z for 2.5D world
        float angleDeg = Mathf.Rad2Deg * angleRad;

        // subtracts -180 from the angle cuz the character was inverted                                                                
        _characterSprite.transform.rotation = Quaternion.Euler(0f, angleDeg - 180, 0f);
    }
}
