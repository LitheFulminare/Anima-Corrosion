using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _attack;

    private Camera _camera;

    private void OnEnable()
    {
        _attack.action.started += Attack;
    }

    private void OnDisable()
    {
        _attack.action.started -= Attack;
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        // calculate where the player clicks relative to the player
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Vector3 attackDirection = raycastHit.point - transform.position;
            Debug.Log(attackDirection);
        }
    }
}
