using DefaultNamespace;
using UnityEngine;
using Zenject;

public class CarPhysicsMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private WheelCollider[] _wheelColliders;
    [SerializeField] private Transform[] _wheelsTransforms;
    [SerializeField] private float _force = 100;
    [SerializeField] private float _steerAngle = 45;

    [SerializeField] private float _forwardFriction=1;
    [SerializeField] private float _sideFriction=0.5f;
    [SerializeField] private float _stiffness=0.5f;
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
      //  MakeWhellsDrift();
    }

    private void MakeWhellsDrift()
    {
        for (int i = 0; i < _wheelColliders.Length; i++)
        {
            WheelFrictionCurve wheelForwardFrictionCurve = _wheelColliders[i].forwardFriction;
            WheelFrictionCurve wheelSideFrictionCurve = _wheelColliders[i].sidewaysFriction;

            wheelForwardFrictionCurve.stiffness = _stiffness;
            wheelSideFrictionCurve.stiffness = _stiffness;
          
            
            wheelForwardFrictionCurve.asymptoteValue = _forwardFriction;
            wheelSideFrictionCurve.asymptoteValue = _sideFriction;
            
            _wheelColliders[i].forwardFriction = wheelForwardFrictionCurve;
            _wheelColliders[i].sidewaysFriction = wheelSideFrictionCurve;

        }
    }

    void FixedUpdate()
    {
        float gasInput = _input.GasInput;
        float rotateInput = -_input.RotateInput;

        for (int i = 0; i < _wheelColliders.Length; i++)
        {
            if (gasInput <= 0)
            {
                _wheelColliders[i].brakeTorque = 100;
            }
            else
            {
                _wheelColliders[i].brakeTorque = 0;
            }

            if (i< 2)
            {
                _wheelColliders[i].steerAngle = rotateInput * _steerAngle ;
                _wheelColliders[i].motorTorque = gasInput * _force;
            }
          

            RotateWheels(i);
        }

        CameraTargetmove();
    }

    private void RotateWheels(int i)
    {
        Vector3 pos = _transform.position;
        Quaternion rot = _transform.rotation;
        _wheelColliders[i].GetWorldPose(out pos, out rot);
        _wheelsTransforms[i].position = pos;
        _wheelsTransforms[i].rotation = rot;
    }

    private void CameraTargetmove()
    {
        if (_rb.velocity.magnitude > 3)
        {
            _cameraTarget.forward = _rb.velocity.normalized;
        }
        else
        {
            _cameraTarget.forward = _transform.forward;
        }
    }
}