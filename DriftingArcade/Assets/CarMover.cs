using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class CarMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    // [SerializeField] private AnimationCurve _tractionOverSpeed;
    // [SerializeField] private AnimationCurve _steerAngleOverSpeed;
    public float MoveSpeed = 50;
    public float MaxSpeed = 15;
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 0.1f;


    private Vector3 MoveForce;
    private IInput _input;
    private Transform _transform;

    [Inject]
    private void Construct(IInput input)
    {
        _input = input;
    }

    private void Start()
    {
        _transform = transform;
    }

    void FixedUpdate()
    {
        MoveForce += GetForwardForce();
        _transform.position += MoveForce * Time.deltaTime;

        _transform.Rotate(GetRotation());

        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        Debug.DrawRay(_transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(_transform.position, _transform.forward * 3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, _transform.forward, TractionDelta()) *
                    MoveForce.magnitude;
        _cameraTarget.forward = MoveForce.normalized;
    }

    private float TractionDelta() => Traction * Time.deltaTime;

    private float CurrentSpeed => MoveForce.magnitude;
    private float PercentOfMaxSpeed => CurrentSpeed / MaxSpeed;

    private Vector3 GetRotation() => Vector3.up * (_input.RotateInput * SteerAngle * Time.deltaTime);

    private Vector3 GetForwardForce()
    {
        return transform.forward * (MoveSpeed * _input.GasInput * Time.deltaTime);
    }
}