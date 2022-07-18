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
    // Define integer variables
    public float MaxDisplacement;
    public float DoorAPos;
    public float DoorBPos;
    public float StartDoorA;
    public float StartDoorB;

    // Define Game Objects for Door's A and B
    public GameObject DoorA;
    public GameObject DoorB;

    // NOTE: Max displacement = 1.698 +/- Z

    // Start is called before the first frame update
    void Start()
    {
        // Inistantiate public integer variables
        MaxDisplacement = 1.698f;

        // Instantiate initiatial position of doors
        StartDoorA = DoorA.transform.position.z;
        StartDoorB = DoorB.transform.position.z;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Create a function that inputs start and end positions of doors, converts
     value on a fraction and increments the door's position using a Sine function
     */
    public void ActivateDoor(float StartPos, float Position, float Displacement)
    {
        for (float i = 1; i <= 500; i++)
        {
            float Fraction = 1 - 1f / i;
            //Position += Fraction * Mathf()
        }
    }
}
