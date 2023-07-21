using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Purpose: Change the rotational speed of the propellors of a drone based on
 * the normalized input value returned from the right VR controller
*/

public class PropellerSpeed : MonoBehaviour
{
    // Define GameObject objects to store the propellers
    [SerializeField] private GameObject FrontRight;
    [SerializeField] private GameObject FrontLeft;
    [SerializeField] private GameObject BackRight;
    [SerializeField] private GameObject BackLeft;

    // Define a Vector3 object to define the rotation angles of the props
    private Vector3 RotationAngles;

    // Create a object from ControllerData class
    public ControllerData InputData;

    void Start()
    {
        // Instantiate maximum rotation angle for the propellers
        RotationAngles = new Vector3(0, 360.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Control the speed of the motor based on trigger input
        ScaledRotation(InputData.TriggerButtonValue * -1.0f, FrontRight);
        ScaledRotation(InputData.TriggerButtonValue, FrontLeft);
        ScaledRotation(InputData.TriggerButtonValue, BackRight);
        ScaledRotation(InputData.TriggerButtonValue * -1.0f, BackLeft);

    }

    // FUNCTION: Spin Propellers
    private void ScaledRotation(float TriggerValue, GameObject Propeller)
    {
        // Define the maximum rotation speed as a multiple input trigger value
        float RotationSpeed = 3.0f * TriggerValue;

        // Rotate the object
        // transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        Propeller.transform.Rotate(RotationAngles * Time.deltaTime * RotationSpeed);
    }
}
