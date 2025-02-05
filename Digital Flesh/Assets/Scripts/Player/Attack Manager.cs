using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _attack;
    [SerializeField] private Transform _swordPivotTransform;

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
        //attackPosition.y = 0f;
        //_swordPivotTransform.rotation = Quaternion.LookRotation(attackPosition);

        _swordPivotTransform.rotation = Quaternion.identity;

        if (Mathf.Abs(attackPosition.z) > Mathf.Abs(attackPosition.x))
        {
            // attack forward
            if (attackPosition.z > 0)
            {
                _swordPivotTransform.Rotate(0f, 0f, 0f);
            }
            //attack backwards
            else
            {
                _swordPivotTransform.Rotate(0f, 180f, 0f);
            }
        }
        else
        {
            // attack to the right
            if (attackPosition.x > 0)
            {
                _swordPivotTransform.Rotate(0f, 90f, 0f);
            }
            // attack to the left
            else
            {
                _swordPivotTransform.Rotate(0f, 270f, 0f);
            }
        }
    }
}
