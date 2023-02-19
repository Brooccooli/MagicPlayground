using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _boostSpeed = 5;
    
    private Rigidbody _body;
    private float _speed = 0;
    private float _acceleration = 100f;
    private float _maxSpeed = 200;

    private Vector3 _lastFrameVelocity;
    
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _controls();
    }

    private void _controls()
    {
        // Forward and backwards
        if (Input.GetKey(KeyCode.W))
        {
            _speed = _acceleration;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _speed = -_acceleration;
        }
        else
        {
            _speed *= 0.5f;
        }

        _speed = Mathf.Clamp(_speed, -_maxSpeed, _maxSpeed);
        
        _body.AddForce(transform.forward * _speed);
        
        // Sides, up and down
        if (Input.GetKey(KeyCode.A))
        {
            _body.AddForce(-transform.right * Mathf.Abs(_speed));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _body.AddForce(transform.right * Mathf.Abs(_speed));
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            _body.AddForce(transform.up * Mathf.Abs(_speed));
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            _body.AddForce(-transform.up * Mathf.Abs(_speed));
        }
        
        // Boost
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _body.AddForce(transform.forward * _boostSpeed, ForceMode.Impulse);
            print("boost");
        }

        _lastFrameVelocity = _body.velocity;
    }

    // FIX, sending player in the wrong direction rn
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 forceDir =  -_lastFrameVelocity.normalized;
        float speed = _body.velocity.magnitude * 0.5f;
        _body.velocity = Vector3.zero;
        _speed = 0;
        _body.AddForce(forceDir * speed, ForceMode.Impulse);
    }
}
