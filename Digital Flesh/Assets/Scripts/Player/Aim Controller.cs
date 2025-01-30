using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimController : MonoBehaviour
{
    [SerializeField] private InputActionReference aim;

    private bool _isAiming = false;

    private void OnEnable()
    {
        aim.action.started += Aim;
    }

    private void OnDisable()
    {
        aim.action.started -= Aim;
    }

    private void Aim(InputAction.CallbackContext context)
    {
        Debug.Log("RMB pressed");
    }
}
