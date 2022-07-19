using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Open and close teleportation pad doors when character moves closer
   to the door

   Door A will be the Right door relative to the character controller -> +Z
   Door B will be the Left door relative to the character controller -> -Z
*/

public class TeleportDoors : MonoBehaviour
{
    // Define Game Objects for Door's A and B
    public GameObject DoorA;
    public GameObject DoorB;

    // Define Game Object for Sensor
    public Collider Sensor;

    // Define Boolean to detect player interaction
    public bool PlayerDetected;

    // Define Boolean for sate of door
    public bool Opening;

    // NOTE: Max displacement = 1.698 +/- Z
    // Define variable for maximum door opening distance
    public float MaxOpenDistance = 1.698f;

    // Define variables to get inititial position of doors
    public Vector3 DoorAPos;
    public Vector3 DoorBPos;

    // Define varible to control door open speed
    public float DoorOpenSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate initiate position of doors to Vector3 variables
        DoorAPos = DoorA.transform.position;
        DoorBPos = DoorB.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if player is here or not
        SensorOnTrigger(Sensor);
        SensorOffTrigger(Sensor);

        // Open the door if the player is detected and if door is not fully open
        if (PlayerDetected)
        {
            if (DoorA.transform.position.z < DoorAPos[2] + MaxOpenDistance)
            {
                if (DoorB.transform.position.z > DoorBPos[2] - MaxOpenDistance)
                {
                    DoorA.transform.Translate(DoorAPos[0], DoorAPos[1], DoorOpenSpeed * Time.deltaTime);
                    DoorB.transform.Translate(DoorBPos[0], DoorBPos[1], -1 * DoorOpenSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            if (DoorA.transform.position.z > DoorAPos[2])
            {
                if (DoorA.transform.position.z < DoorBPos[2])
                {
                    // For now do nothing
                }
            }
        }
    }

    // Function checks if the player is at the sensor
    private void SensorOnTrigger(Collider Object)
    {
        if (Object.gameObject.tag == "Player")
        {
            PlayerDetected = true;
        }
    }

    // Function check if the player is not at the sensor
    private void SensorOffTrigger(Collider Object)
    {
        if (Object.gameObject.tag != "Player")
        {
            PlayerDetected = false;
        }
    }
}
