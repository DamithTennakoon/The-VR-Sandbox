using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerData : MonoBehaviour
{
    // Create a public variable for access
    public float ScaleValue;

    // Define array for game objects
    public GameObject[] Controllers;

    // Define variable for tag name
    public string tagName;

    // Define variables for vectors positions
    public Vector3 Controller1;
    public Vector3 Controller2;

    // Create an input device object
    private InputDevice TargetDevice;

    // Create a boolean to store primary button data
    public bool PrimaryButtonValue;


    void Start()
    {
        // Define tag name
        tagName = "VR Controller";

        // Find all current game objects with target tag name
        Controllers = GameObject.FindGameObjectsWithTag(tagName);

        // Create a list contaianing all detected devices
        List<InputDevice> Devices = new List<InputDevice>();

        InputDeviceCharacteristics RightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

        // Get the right controller from the devices list and save that as the new list of devices
        InputDevices.GetDevicesWithCharacteristics(RightControllerCharacteristics, Devices);

        // If the device count of the searched controller is present, select that controller 
        if (Devices.Count > 0)
        {
            // Instatiate the input device object 
            TargetDevice = Devices[0];
        
        }

    }

    // Update is called once per frame
    void Update()
    {
        //ScaleValue = 5.0f;
        Controllers = GameObject.FindGameObjectsWithTag(tagName);

        // Compute the distance between the two controller objects
        if (Controllers.Length > 0)
        {
            ScaleValue = Vector3.Distance(Controllers[0].transform.position, Controllers[1].transform.position);
            Controller1 = Controllers[0].transform.position;
            Controller2 = Controllers[1].transform.position;
        }
        else
        {
            ScaleValue = 1.0f;
        }

        // Check if the primary button is pressed
        TargetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out PrimaryButtonValue);
        
    }
}
