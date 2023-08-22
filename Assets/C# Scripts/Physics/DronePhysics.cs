using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Purpose: Control the state of the drone based on input from controller data
 * from the VR controller.
*/
public class DronePhysics : MonoBehaviour
{
    // Define GameObject objects to store the propellers
    [SerializeField] private GameObject FrontRight;
    [SerializeField] private GameObject FrontLeft;
    [SerializeField] private GameObject BackRight;
    [SerializeField] private GameObject BackLeft;

    // Define RigidBody object to store drone's rigid body property
    [SerializeField] private Rigidbody DroneRigidBody;

    // Define Transform object to store transform of drone
    [SerializeField] private Transform DroneTransform;

    // Define Floats object to store the distance between drone and propellors
    [SerializeField] private float DistFrontRight;
    [SerializeField] private float DistFrontLeft;
    [SerializeField] private float DistBackRight;
    [SerializeField] private float DistBackLeft;

    // Implement proportional gains
    private float p_gain_pitch;
    private float p_gain_roll;
    private float p_gain_yaw;

    // Implement derivative gains
    private float d_gain_pitch;
    private float d_gain_roll;

    // Sensor data objects
    public float PitchError;
    public float RollError;
    public float YawError;


    // Derivative controller objects
    public float PitchErrorRate;
    public float RollErrorRate;
    public float PreviousPitchError;
    public float PreviousRollError;
    public float dt;

    // Create a object from ControllerData class
    public ControllerData InputData;

    void Start()
    {
        // Initialize sensor data;
        PitchError = 0.0f;
        RollError = 0.0f;
        YawError = 0.0f;

        // Initialize proportional gains
        p_gain_pitch = 25f;
        p_gain_roll = 2f;
        p_gain_yaw = 6f;

        // Initialize derivative gains
        d_gain_pitch = 0.5f;
        d_gain_roll = 0.005f;

        // Initialize derivate controller object values
        PitchErrorRate = 0.0f;
        RollErrorRate = 0.0f;
        PreviousPitchError = 0.0f;
        PreviousRollError = 0.0f;
        dt = 0.01f;

        // Initialize distances between propes and centre of drone mass
        DistFrontRight = Vector3.Distance(FrontRight.transform.position, DroneTransform.position);
        DistFrontLeft = Vector3.Distance(FrontLeft.transform.position, DroneTransform.position);
        DistBackRight = Vector3.Distance(BackRight.transform.position, DroneTransform.position);
        DistBackLeft = Vector3.Distance(BackLeft.transform.position, DroneTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        // Sensor data computation
        //InputData.TriggerButtonValue = 0.52f;
        PitchError = ComputePitchError(DroneTransform);
        RollError = ComputeRollErorr(DroneTransform);
        YawError = ComputeYawError(DroneTransform);

        // Compute error rates
        PitchErrorRate = ComputePitchErrorRate(PreviousPitchError, PitchError, dt);
        RollErrorRate = ComputeRollErrorRate(PreviousRollError, RollError, dt);

        // Add force to each propellor
        Forces(InputData.TriggerButtonValue, FrontRight, FrontLeft, BackRight, BackLeft, p_gain_pitch, p_gain_roll, p_gain_yaw, d_gain_pitch, d_gain_roll, PitchError, RollError, YawError, PitchErrorRate, RollErrorRate);

    }

    // TO-DO: Function: add force to rigid body
    private void Forces(float TriggerValue, GameObject FR_Prop, GameObject FL_Prop, GameObject BR_Prop, GameObject BL_Prop, float p_gain_pitch, float p_gain_roll, float p_gain_yaw, float d_gain_pitch, float d_gain_roll, float PitchError, float RollError, float YawError, float PitchErrorRate, float RollErrorRate)
    {
        // Temporary: float object to save force value
        float Force = 10f * TriggerValue;
        float RollControlForce = 0.5f;
        float PitchControlForce = 4.0f;

        // Add force to each rotor
        float FR_Force = Force;
        float FL_Force = Force;
        float BR_Force = Force;
        float BL_Force = Force;

        // Compute Pitch, Roll, and Yaw stabilization forces using propotional controller terms
        FR_Force = FR_Force + ((PitchError) * p_gain_pitch) - ((RollError) * p_gain_roll) - ((YawError) * p_gain_yaw);
        FL_Force = FL_Force + ((PitchError) * p_gain_pitch) + ((RollError) * p_gain_roll) + ((YawError) * p_gain_yaw);
        BR_Force = BR_Force - ((PitchError) * p_gain_pitch) - ((RollError) * p_gain_roll) + ((YawError) * p_gain_yaw);
        BL_Force = BL_Force - ((PitchError) * p_gain_pitch) + ((RollError) * p_gain_roll) - ((YawError) * p_gain_yaw);

        // Compute Pitch stabilization forces using derivate controller terms
        FR_Force = FR_Force - ((PitchErrorRate) * d_gain_pitch) + ((RollErrorRate) * d_gain_roll);
        FL_Force = FL_Force - ((PitchErrorRate) * d_gain_pitch) - ((RollErrorRate) * d_gain_roll);
        BR_Force = BR_Force + ((PitchErrorRate) * d_gain_pitch) + ((RollErrorRate) * d_gain_roll);
        BL_Force = BL_Force + ((PitchErrorRate) * d_gain_pitch) - ((RollErrorRate) * d_gain_roll);

        // Flight controlls
        float PitchInput = InputData.RightJoystick[1];
        float RollInput = InputData.RightJoystick[0];

        FR_Force = FR_Force - ((PitchControlForce) * (PitchInput)) - ((RollControlForce) * (RollInput));
        FL_Force = FL_Force - ((PitchControlForce) * (PitchInput)) + ((RollControlForce) * (RollInput));
        BR_Force = BR_Force + ((PitchControlForce) * (PitchInput)) - ((RollControlForce) * (RollInput));
        BL_Force = BL_Force + ((PitchControlForce) * (PitchInput)) + ((RollControlForce) * (RollInput));

        // Add force to propellor object
        DroneRigidBody.AddForceAtPosition(transform.up * FR_Force, FR_Prop.transform.position);
        DroneRigidBody.AddForceAtPosition(transform.up * FL_Force, FL_Prop.transform.position);
        DroneRigidBody.AddForceAtPosition(transform.up * BR_Force, BR_Prop.transform.position);
        DroneRigidBody.AddForceAtPosition(transform.up * BL_Force, BL_Prop.transform.position);

        // Compute the torque generated by each motor
        float FR_Torque = FR_Force * DistFrontRight * Mathf.Sin(90) * -1;
        float FL_Torque = FL_Force * DistFrontLeft * Mathf.Sin(90);
        float BR_Torque = BR_Force * DistBackRight * Mathf.Sin(90);
        float BL_Torque = BL_Force * DistBackLeft * Mathf.Sin(90) * -1;

        // Add torque to drone rigid body
        DroneRigidBody.AddTorque(transform.up * FR_Torque);
        DroneRigidBody.AddTorque(transform.up * FL_Torque);
        DroneRigidBody.AddTorque(transform.up * BR_Torque);
        DroneRigidBody.AddTorque(transform.up * BL_Torque);


    }

    // Function: Return the pitch angle of the drone
    private float ComputePitchError(Transform DroneTransform)
    {
        // Caculate the current rotation of the transform
        float CurPitchError = -1*DroneTransform.rotation.x;

        return CurPitchError;
    }

    // Function: Return the roll angle of the drone
    private float ComputeRollErorr(Transform DroneTransform)
    {
        // Calculate the current rotation of the transform
        RollError = -1*DroneTransform.rotation.z;

        return RollError;
    }

    // Function: Return the yaw angle of the drone
    private float ComputeYawError(Transform DroneTransform)
    {
        // Calculate the current rotation of the transform
        float YawError = -1 * DroneTransform.rotation.y;

        return YawError;
    }

    // Function: Return the error rate of the pitch axis
    private float ComputePitchErrorRate(float PreviousError, float CurrentError, float dt)
    {
        // Compute error rate
        float ErrorRate = (PreviousError - CurrentError) / dt;

        // Update error values
        PreviousPitchError = CurrentError;

        return ErrorRate;
    }

    // Function: Return the error rate of the roll axis
    private float ComputeRollErrorRate(float PreviousError, float CurrentError, float dt)
    {
        // Compute error rate
        float ErrorRate = (PreviousError - CurrentError) / dt;

        // Update error values
        PreviousRollError = CurrentError;

        return ErrorRate;
    }
}
