using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] Transform CenterOfMass;
    [SerializeField] WheelCollider[] Wheels;
    [SerializeField] Transform[] obj;

    [SerializeField] string XAxisName = "Horizontal";
    [SerializeField] string YAxisName = "Vertical";
    [SerializeField] KeyCode BrakeKey = KeyCode.Space;

    [SerializeField] Vector2 InputVector;
    [SerializeField] float BrakeInput = 0;

    [SerializeField] float AccelPower = 1000f;
    [SerializeField] float HandleAngle = 45f;
    [SerializeField] float BrakePower = 1000f;

    [SerializeField] float[] DriveWheels = new float[] { 0f, 0f, 1.0f, 1.0f };
    [SerializeField] float[] SteerWheels = new float[] { 1.0f, 1.0f, 0f, 0f };

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Wheels = GetComponentsInChildren<WheelCollider>();
        rb.centerOfMass = CenterOfMass.localPosition;

        obj = new Transform[Wheels.Length];
        for (int i = 0; i < Wheels.Length; i++)
        {
            obj[i] = Wheels[i].transform.GetChild(0);
        }
    }

    private void Update()
    {
        ControlInput();

        CarControl();

    }

    private void ControlInput()
    {
        InputVector = new Vector2(Input.GetAxis(XAxisName), Input.GetAxis(YAxisName));
        BrakeInput = Input.GetKey(BrakeKey) ? BrakePower : 0f;
    }

    private void CarControl()
    {
        for (int i = 0;i < Wheels.Length;i++)
        {
            Wheels[i].motorTorque = InputVector.y * DriveWheels[i] * AccelPower;
            Wheels[i].steerAngle = InputVector.x * SteerWheels[i] * HandleAngle;
            Wheels[i].brakeTorque = BrakeInput;

            Vector3 _pos;
            Quaternion _dir;
            Wheels[i].GetWorldPose(out _pos, out _dir);
            obj[i].position = _pos;
            obj[i].rotation = _dir;
        }
    }
}
