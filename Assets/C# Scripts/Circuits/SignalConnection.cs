using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import UI tools
using UnityEngine.UI;

// Goal: Detect the collision between Arduino and Desk Floater to Turn Display On and Off

public class SignalConnection : MonoBehaviour
{
    // Define game object for detection device
    public GameObject Floater;

    // Create a game object for the display ~ to be toggled
    public Canvas Display;

    // Start is called before the first frame update
    void Start()
    {
        // Begin with the diplay off
        Display.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detect collision to Arduino Board
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arduino")
        {

            Display.enabled = true;

        }
    }

    // Detect if Arduino has been removed ~ unplugged
    /*
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Arduino")
        {
            Display.enabled = false;
        }
    }*/
    
}
