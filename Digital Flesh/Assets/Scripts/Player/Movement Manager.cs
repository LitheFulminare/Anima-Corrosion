using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;

    // movement speed and direction parameters
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private float _playerSpeed = 2.0f;
    private float _jumpHeight = 1.0f;
    private float _gravityValue = -9.81f;
    private Vector2 _moveDirection;

    public InputActionReference move;

    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();

        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        // converts the Vector2 input to a Vector3 (otherwise 'W' makes the character jump)
        Vector3 moveDirection = new Vector3(_moveDirection.x, 0, _moveDirection.y);
        _controller.Move(moveDirection * Time.deltaTime * _playerSpeed);

        // Makes the player jump
        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -2.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    // slows player down when aiming
    public void SlowOnAim(bool isAiming)
    {
        if (isAiming)
        {
            _playerSpeed = 1.0f;
        }
        else
        {
            _playerSpeed = 2.0f;
        }
    }
}
