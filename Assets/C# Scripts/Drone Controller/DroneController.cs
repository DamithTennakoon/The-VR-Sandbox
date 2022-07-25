using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import UI tools
using UnityEngine.UI;

// Radio controller for drone (MECH lab)

public class DroneController : MonoBehaviour
{
    // Define Game object for Drone body
    public GameObject Drone;

    // Define Slider object for Throttle slider
    public Slider ThrottleSlider;

    // Define Slider object for Roll slider
    public Slider RollSlider;

    // Define Slider object for Roll slider
    public Slider PitchSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Throttle drone up/down
        Drone.transform.Translate(0f, ThrottleSlider.value * Time.deltaTime, 0f);

        // Roll drone
        Drone.transform.Translate(RollSlider.value * Time.deltaTime, 0f, 0f);

        // Pitch drone
        Drone.transform.Translate(0f, 0f, PitchSlider.value * Time.deltaTime);

        Drone.transform.Rotate(0f, 0f, 0f);

    }

    // Check if radio controller toggle is on and turn off gravity is true
    public void GravitySwitchOn(bool Toggle)
    {
        if (Toggle == true)
        {
            Drone.GetComponent<Rigidbody>().useGravity = false;

            // Stabalize Drone
            //Drone.transform.Rotate(0f, 0f, 0f);
        }
        else
        {
            Drone.GetComponent<Rigidbody>().useGravity = true;

            // Reset toggle values
            ThrottleSlider.value = 0;
            RollSlider.value = 0;
            PitchSlider.value = 0;
        }
    }

}
