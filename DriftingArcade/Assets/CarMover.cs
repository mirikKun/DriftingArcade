using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class CarMover : MonoBehaviour
{

    [SerializeField] private Transform _cameraTarget;
    public float MoveSpeed = 50;
       public float MaxSpeed = 15;
       public float Drag = 0.98f;
       public float SteerAngle = 20;
       public float Traction = 1;
   

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

       void Update() {
   
           MoveForce += GetForwardForce();
           _transform.position += MoveForce * Time.deltaTime;
   
           _transform.Rotate(GetRotation());
   
           MoveForce *= Drag;
           MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);
           
           Debug.DrawRay(_transform.position, MoveForce.normalized * 3);
           Debug.DrawRay(_transform.position, _transform.forward * 3, Color.blue);
           MoveForce = Vector3.Lerp(MoveForce.normalized, _transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;
           _cameraTarget.forward = MoveForce.normalized;
       }

       private Vector3 GetRotation()
       {
           return Vector3.up * (_input.RotateInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);
       }

       private Vector3 GetForwardForce()
       {
           return transform.forward * (MoveSpeed * _input.GasInput * Time.deltaTime);
       }
}
