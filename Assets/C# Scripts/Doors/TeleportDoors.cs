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
    //public Collider Sensor;

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
    public float DoorOpenSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate initiate position of doors to Vector3 variables
        DoorAPos = DoorA.transform.position;
        DoorBPos = DoorB.transform.position;

        Debug.Log(DoorAPos);

        // Instantiate state of sensor and door
        PlayerDetected = false;
        Opening = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Open the door if the player is detected and if door is not fully open
        if (PlayerDetected)
        {
            /*
            if (DoorA.transform.position.z < DoorAPos[2] + MaxOpenDistance)
            {
                DoorA.transform.Translate(new Vector3(DoorAPos.x, DoorAPos.y, DoorAPos.z), Space.Self);

            }

            if (DoorB.transform.position.z > DoorBPos[2] - MaxOpenDistance)
            {
                DoorB.transform.Translate(0, -1 * DoorOpenSpeed * Time.deltaTime, 0, Space.Self);
            }
            */

            DoorA.transform.position = new Vector3(DoorAPos.x, DoorAPos.y, DoorAPos.z + MaxOpenDistance);
            DoorB.transform.position = new Vector3(DoorBPos.x, DoorBPos.y, DoorBPos.z - MaxOpenDistance);

        }
        else
        {   /*
            if (DoorA.transform.position.z > DoorAPos[2])
            {
                if (DoorA.transform.position.z < DoorBPos[2])
                {
                    // For now do nothing
                }
            }*/
            DoorA.transform.position = DoorAPos;
            DoorB.transform.position = DoorBPos;
        }
    }

    // Function checks if the player is at the sensor
    private void OnTriggerEnter(Collider Sensor)
    {
        if (Sensor.gameObject.tag == "Player")
        {
            PlayerDetected = true;
        }
    }

    // Function check if the player is not at the sensor
    private void OnTriggerExit(Collider Sensor)
    {
        if (Sensor.gameObject.tag == "Player")
        {
            PlayerDetected = false;
        }
    }

}
