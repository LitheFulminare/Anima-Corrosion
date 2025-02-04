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

            GetAttackDirection(attackDirection);

            //Debug.Log(attackDirection);
        }
    }

    // gets the click position and determines the actual direction (forward, backward, right, left)
    private void GetAttackDirection(Vector3 attackPosition)
    {
        if (Mathf.Abs(attackPosition.z) > Mathf.Abs(attackPosition.x))
        {
            if (attackPosition.z > 0)
            {
                Debug.Log("attacked forwards");
            }
            else
            {
                Debug.Log("attacked backwards");
            }
        }
        else
        {
            if (attackPosition.x > 0)
            {
                Debug.Log("attacked to the right");
            }
            else
            {
                Debug.Log("attacked to the left");
            }
        }
    }
}
