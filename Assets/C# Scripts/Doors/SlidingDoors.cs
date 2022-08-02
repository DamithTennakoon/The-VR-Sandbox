using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Goal: Linear door transformation (sliding door motion)

public class SlidingDoors : MonoBehaviour
{
    // Define Boolean to check trigger zone(sensor)
    private bool Trigger;

    // Define Game Object for Doors A and B
    public GameObject DoorA, DoorB;

    // Define Vector3 variables to store start and end positions
    private Vector3 StartDoorA, StartDoorB, EndDoorA, EndDoorB;

    // Define distance the doors will open
    float OpenDistance = 2f;

    // Define variable to control the rate at which the doors slide open
    float OpenSpeed = 1.2f;

    // Define Game Object to the access light (to be able to change its material)
    public GameObject FrontAccessLight, BackAccessLight;

    // Define Material objects to store access allowed/denied materials
    public Material AccessGrantedMat, AccessDeniedMat;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate trigger zone to false
        Trigger = false;

        // Instantiate start positions of doors based on in-game placement
        StartDoorA = DoorA.transform.position;
        StartDoorB = DoorB.transform.position;

        // Define end positions of doors (NOTE: travel on z-axis)
        EndDoorA = new Vector3(StartDoorA[0], StartDoorA[1], StartDoorA[2] + OpenDistance);
        EndDoorB = new Vector3(StartDoorB[0], StartDoorB[1], StartDoorB[2] - OpenDistance);

    }

    // Update is called once per frame
    void Update()
    {

        // Open the door if player is on the sensor, else close the door
        if (Trigger)
        {

            if (DoorA.transform.position.z <= EndDoorA.z)
            {
                DoorA.transform.Translate(0f, 0f, OpenSpeed * Time.deltaTime);
            }

            if (DoorB.transform.position.z >= EndDoorB.z)
            {
                DoorB.transform.Translate(0f, 0f, -OpenSpeed * Time.deltaTime);
            }

        }
        else
        {
            if (DoorA.transform.position.z >= StartDoorA.z)
            {
                DoorA.transform.Translate(0f, 0f, -OpenSpeed * Time.deltaTime);
            }

            if (DoorB.transform.position.z <= StartDoorB.z)
            {
                DoorB.transform.Translate(0f, 0f, OpenSpeed * Time.deltaTime);
            }

            // Reset door position to avoid glitches from Time.deltaTime
            if (DoorA.transform.position.z < StartDoorA.z)
            {
                DoorA.transform.position = StartDoorA;
            }

            if (DoorB.transform.position.z > StartDoorB.z)
            {
                DoorB.transform.position = StartDoorB;
            }
        }


        // Close the door if the player is not on the sensor
    }


    // Function to check if player is on trigger zone
    private void OnTriggerEnter(Collider TrigZone)
    {
        if (TrigZone.gameObject.tag == "Player")
        {
            Trigger = true;

            // Change material to access granted
            FrontAccessLight.GetComponent<MeshRenderer>().material = AccessGrantedMat;
            BackAccessLight.GetComponent<MeshRenderer>().material = AccessGrantedMat;
        }
    }

    // Function to check if player has left the trigger zone
    private void OnTriggerExit(Collider TrigZone)
    {
        if (TrigZone.gameObject.tag == "Player")
        {
            Trigger = false;

            // Change material to access denied
            FrontAccessLight.GetComponent<MeshRenderer>().material = AccessDeniedMat;
            BackAccessLight.GetComponent<MeshRenderer>().material = AccessDeniedMat;
        }
    }

}
