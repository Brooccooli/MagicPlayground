using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private enum behavior
    {
        Flee,
        Idle,
        Attack
    }

    private behavior _state = behavior.Idle;
    private Rigidbody _body;
    private bool _activeBehavior = true;
    private float _behaviorChangeTimer = 0;
    private float _timeBetweenBehavoirChange = 2;
    private float distToGround;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;
    }
    
    void Update()
    {
        _behaviorChangeTimer -= Time.deltaTime;

        
        if (IsGrounded())
        {
            // State Machine
            switch (_state)
            {
                case behavior.Idle:
                {
                    _idle();
                    break;
                }
                default: break;
            }
            
            _body.MoveRotation(Quaternion.Euler(Vector3.up));
        }
        
        if (_behaviorChangeTimer <= 0)
        {
            _behaviorChangeTimer = _timeBetweenBehavoirChange;
        }
    }
    
    bool IsGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void _idle()
    {
        if (_activeBehavior)
        {
            _body.AddForce(transform.forward);
        }

        if (_behaviorChangeTimer <= 0)
        {
            _activeBehavior = !_activeBehavior;
            _body.MoveRotation(new Quaternion(0, Random.Range(1, 360), 0, 0));;
        }
    }
}
