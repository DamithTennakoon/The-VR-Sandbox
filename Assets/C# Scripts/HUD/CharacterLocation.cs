using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
// Import UI tools
using UnityEngine.UI;

// The purpose of this script is to display the character controllers location
// on the user HUD


public class CharacterLocation : MonoBehaviour
{
    // Create character controller game object
    public GameObject CharacterPosition;

    // Create a Vector object to store character position
    public Vector3 Position;

    // Create Text object for Longitude
    public Text LongitudeText;

    // Create Text object for Latitude
    public Text LatitudeText;

    // Create Text object for Elevation
    public Text Elevation;


    // Start is called before the first frame update
    void Start()
    {
        // Instantiate the Vector 3 at origin
        Position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Store the character position in to Position vector
        Position = CharacterPosition.transform.position;

        // Update the lat, long, elev text
        UpdatePlayerLocation(Position);

    }

    // Function: Updates the lat, long, elev text
    public void UpdatePlayerLocation(Vector3 Position)
    {
        // Update Logitude text (first convert to string)
        LongitudeText.text = Position[0].ToString();

        // Update Latitude text (first convert to string)
        LatitudeText.text = Position[2].ToString();

        // Update Elevation text (first convert to string)
        Elevation.text = Position[1].ToString();
    }
}
