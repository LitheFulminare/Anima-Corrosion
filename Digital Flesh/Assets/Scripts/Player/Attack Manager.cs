using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _attack;

    private void OnEnable()
    {
        _attack.action.started += Attack;
    }

    private void OnDisable()
    {
        _attack.action.started -= Attack;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack");
    }
}
