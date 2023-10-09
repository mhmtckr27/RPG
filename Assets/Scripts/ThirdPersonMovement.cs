using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1000f;
    [SerializeField] private float _moveSpeed = 5f;
    
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    { 
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        float lookInput = Input.GetAxis("Mouse X");
        _transform.Rotate(0, lookInput * _rotateSpeed * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        float verticalMoveInput = Input.GetAxis("Vertical");
        float horizontalMoveInput = Input.GetAxis("Horizontal");

        Vector3 velocity = new Vector3(horizontalMoveInput, 0, verticalMoveInput);
        velocity.Normalize();
        velocity *= _moveSpeed * Time.fixedDeltaTime;

        Vector3 moveOffset = _transform.rotation * velocity;
        Vector3 newPosition = _transform.position + moveOffset;
        
        _rigidbody.MovePosition(newPosition);
    }
}
