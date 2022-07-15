using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    // Create an object to listen for controller characteristics
    public InputDeviceCharacteristics ControllerCharacteristics;

    // Create a list of objects for the controll models
    public List<GameObject> ControllerPrefabs;

    // Create an input device object
    private InputDevice TargetDevice;

    // Create a game object to refer to controller
    private GameObject SpawnedController;

    // Start is called before the first frame update
    void Start()
    {
        // Create a list contaianing all detected devices
        List<InputDevice> Devices = new List<InputDevice>();

        // Get the right controller from the devices list and save that as the new list of devices
        InputDevices.GetDevicesWithCharacteristics(ControllerCharacteristics, Devices);

        // If the device count of the searched controller is present, select that controller 
        if (Devices.Count > 0)
        {
            // Instatiate the input device object 
            TargetDevice = Devices[0];

            // Get the correct controller prefab (the one that matches the name of device)
            // NOTE: Name of device detected has to match prefab name, else you will get an error
            GameObject Prefab = ControllerPrefabs.Find(controller => controller.name == TargetDevice.name);

            // Spawn the found object as a hand prefab
            if (Prefab)
            {
                SpawnedController = Instantiate(Prefab, transform);
            }
            else
            {
                Debug.LogError("Error: Did not find the corresponding controller model - check names match");

                // If nothing gets found, pick the first controller on the list and spawn that!
                SpawnedController = Instantiate(ControllerPrefabs[0], transform);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
