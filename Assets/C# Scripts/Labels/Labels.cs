using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


// Goal: Generate lines between two start points and two end points for labels

public class Labels : MonoBehaviour
{
    // Start point objects
    [SerializeField] private GameObject startPointArduino;
    [SerializeField] private GameObject startPointD2;

    // End point objects
    [SerializeField] private GameObject endPointArduino;
    [SerializeField] private GameObject endPointD2;



    // Define Line Renderer object to attach in inspector
    public LineRenderer Wire1;
    public LineRenderer Wire2;

    // Define variable to store the render start of labels
    private GameObject[] labelItems;
    //[SerializeField] private bool[] states;

    // Define timer
    private float timeElapsed;
    private float timeInterval;

    // DEMO: Define variable to store the state of all labels
    private bool renderState;

    // DEMO: Define Canvas objects
    [SerializeField] Canvas arduinoCanvas;
    [SerializeField] Canvas d2Canvas;

    // Define XR input system objects
    // Create an object to listen for controller characteristics
    public InputDeviceCharacteristics RightControllerCharacteristics;

    // Create an input device object
    private InputDevice TargetDevice;



    // Start is called before the first frame update
    void Start()
    {
        // Instantiate the number of points within the line
        Wire1.positionCount = 2;
        Wire2.positionCount = 2;
        startPointArduino.GetComponent<MeshRenderer>().enabled = false;
        endPointArduino.GetComponent<MeshRenderer>().enabled = false;
        startPointD2.GetComponent<MeshRenderer>().enabled = false;
        endPointD2.GetComponent<MeshRenderer>().enabled = false;
        Wire1.enabled = false;
        Wire2.enabled = false;
        arduinoCanvas.enabled = false;
        d2Canvas.enabled = false;

        // Initialize timer
        timeElapsed = 0.0f;
        timeInterval = 3.0f;

        // DEMO: Initialize current state
        renderState = startPointArduino.GetComponent<MeshRenderer>().enabled;

        // Initialize label items array
        labelItems = new GameObject[1];
        //states = new bool[labelItems.Length];
        labelItems = GameObject.FindGameObjectsWithTag("Labels");

        // Initialize the states of all the label items
        /*
        for (int i = 0; i < labelItems.Length; i++) {
            states[i] = labelItems[i].GetComponent<MeshRenderer>().enabled;
        }*/

        // Create a list contaianing all detected devices
        List<InputDevice> Devices = new List<InputDevice>();

        // Initialize right controller
        RightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

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
        // Update tiemr
        timeElapsed += Time.deltaTime;

        // Update the start and end positions of line based on object positions
        Wire1.SetPosition(0, startPointArduino.transform.position);
        Wire1.SetPosition(1, endPointArduino.transform.position);
        Wire2.SetPosition(0, startPointD2.transform.position);
        Wire2.SetPosition(1, endPointD2.transform.position);

        // Toggle the mesh render of the spheres from primary input button
        TargetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);


        if (primaryButtonValue && (timeElapsed >= timeInterval))
        {
            //startPointArduino.GetComponent<MeshRenderer>().enabled = !renderState;
            //endPointArduino.GetComponent<MeshRenderer>().enabled = !renderState;
            arduinoCanvas.enabled = !renderState;
            d2Canvas.enabled = !renderState;
            Wire1.enabled = !renderState;
            Wire2.enabled = !renderState;

            renderState = arduinoCanvas.enabled;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
