using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SteeringAgent : MonoBehaviour
{
    Vector3 _velocity;
    [Range(0, 5)][SerializeField] float _maxSpeed;
    [Range(0, 0.1f)][SerializeField] float _maxForce;

    [SerializeField] Transform _target;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        AddForce(Seek(_target.position));
        //Move();
    }
    void FixedUpdate() => FixedMove();

    void Move()
    {
        transform.position += _velocity * Time.deltaTime;
        transform.right = _velocity;
    }
    void FixedMove()
    {
        _rb.MovePosition(transform.position + _velocity * Time.deltaTime);
        transform.right = _velocity;
    }

    Vector3 Seek(Vector3 targetPos) => CalculateSteering(targetPos - transform.position);

    Vector3 CalculateSteering(Vector3 desired) => Vector3.ClampMagnitude((desired.normalized * _maxSpeed) - _velocity, _maxForce);

    void AddForce(Vector3 force) => _velocity = Vector3.ClampMagnitude(_velocity + force, _maxSpeed);

}
