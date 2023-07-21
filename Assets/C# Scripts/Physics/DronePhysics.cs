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

    // Implement proportional controlller for Roll axis
    private float p_gain;

    // Sensor data objects
    public float PitchError;

    // Create a object from ControllerData class
    public ControllerData InputData;



    void Start()
    {
        // Initialize sensor data;
        PitchError = 0.0f;

        // Define proportional gain
        p_gain = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        // Sensor data computation
        PitchError = ComputePitchError(DroneTransform,PitchError);

        // Add force to each propellor
        //InputData.TriggerButtonValue = 0.8f;
        Forces(InputData.TriggerButtonValue, FrontRight, FrontLeft, BackRight, BackLeft, p_gain, PitchError);
    }

    // TO-DO: Function: add force to rigid body
    private void Forces(float TriggerValue, GameObject FR_Prop, GameObject FL_Prop, GameObject BR_Prop, GameObject BL_Prop, float p_gain, float PitchError)
    {
        // Temporary: float object to save force value
        float Force = 12f * TriggerValue;

        float FR_Force = Force + (PitchError) * p_gain;
        float FL_Force = Force + (PitchError) * p_gain;
        float BR_Force = Force - (PitchError) * p_gain;
        float BL_Force = Force - (PitchError) * p_gain;

        // Add force to propellor object
        DroneRigidBody.AddForceAtPosition(transform.up * FR_Force, FR_Prop.transform.position);
        DroneRigidBody.AddForceAtPosition(transform.up * FL_Force, FL_Prop.transform.position);
        DroneRigidBody.AddForceAtPosition(transform.up * BR_Force, BR_Prop.transform.position);
        DroneRigidBody.AddForceAtPosition(transform.up * BL_Force, BL_Prop.transform.position);

        // Roll PID control

    }

    // Function: Return the pitch angle of the drone
    private float ComputePitchError(Transform DroneTransform, float PitchError)
    {
        // Caculate the current rotation of the transform
        PitchError = -1*DroneTransform.rotation.x;

        return PitchError;
    }

    /*
    // Function: Compute proportional gain
    private float ComputeProportionalGain(float Error, float p_gain)
    {
        //


        return p_gain;
    }*/
}
