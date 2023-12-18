using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controller : MonoBehaviour
{
    private PlayerControls _controls;
    private Vector2 _currentDirection = Vector2.right;
    private bool _isMoving = true;
    private float _movementSpeed = 0.3f;
    private float _moveTimer = 0f;
    private GameManager _gameManager;

    private void Awake()
    {
        _controls = new PlayerControls();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (_gameManager.CurrentState != GameState.GameInProgress) 
            return;

        var position = Vector2.zero;

        _moveTimer += Time.deltaTime;

        if(_moveTimer >= _movementSpeed )
        {
            _moveTimer = 0f;
            Vector3 previousPosition = transform.position;
            position += _currentDirection;
        }

        transform.Translate(position);
    }

    private void OnEnable()
    {
        _controls.Player.Enable();
        _controls.Player.Movement.performed += Movement;
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
    }

    private void Movement(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        if (Vector2.Dot(direction, _currentDirection) == -1 && _isMoving)
            return;

        _currentDirection = direction;
        _isMoving = true;

    }
}
