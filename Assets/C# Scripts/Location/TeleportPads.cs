using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Teleport from one teleportation pad to another the destination pad

public class TeleportPads : MonoBehaviour
{
    // Define Game Object for destination teleportation pad
    public GameObject DestinationPad;

    // Define Game Object for character controller
    public GameObject CharacterController;

    // Define Boolean to detect player interaction with teleport pad
    public bool PlayerDetected;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate state of player detection
        PlayerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Teleport the character controller to destination if on teleport pad
        if (PlayerDetected)
        {
            Vector3 DestinationPos = DestinationPad.transform.position;
            CharacterController.transform.position = new Vector3(-24.8600006f, -3.44000006f, -4.51999998f);
        }
        else
        {
            CharacterController.transform.position = CharacterController.transform.position;
        }
    }

    // Function checks if the player is at the teleport pad
    private void OnTriggerEnter(Collider Pad)
    {
        if (Pad.gameObject.tag == "Player")
        {
            PlayerDetected = true;
        }
    }

    // Function check if the player is not at the teleport pad
    private void OnTriggerExit(Collider Pad)
    {
        if (Pad.gameObject.tag == "Player")
        {
            PlayerDetected = false;
        }
    }
}

