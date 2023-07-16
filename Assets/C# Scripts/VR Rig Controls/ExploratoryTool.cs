using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/* Code goal: Check if VR controller prfabs exist, locate their transforms, 
 * create a line renderer between the origins of each transfors (init. goal)
 * Error found: SetActive() mode
*/
public class ExploratoryTool : MonoBehaviour
{

    // Define variable for tag name
    public string tagName;

    // Define array for game objects
    public GameObject[] Controllers;

    // Define Vector3 array to store POS data for controllers' transforms
    public Vector3[] Pos;

    // Object to scale
    //public GameObject Cube;

    // TEST
    public Vector3 temp;

    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        // Define tag name
        tagName = "VR Controller";

        // Define the length of the POS array
        Pos = new Vector3[2];

        // Find all current game objects with target tag name
        Controllers = GameObject.FindGameObjectsWithTag(tagName);


        // If the array is not empty, then hide all the game objects in it
        if (Controllers.Length > 0)
        {
            // Define counter variable
            int counter = 0;

            foreach (GameObject Controller in Controllers)
            {
                //Controller.SetActive(false);

                // Save the position of each controller to POS array
                Pos[counter] = Controller.transform.position;
                counter += 1;
            }
        }

        dist = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if left controller exists
        //ControllerExists();

        // TESTING
        Vector3 ControlPose1 = Controllers[0].transform.position;
        Vector3 ControlPose2 = Controllers[1].transform.position;
        //dist = Vector3.Distance(ControlPose1, ControlPose2);
        dist = 2.0f;
        

    }

    // FUNCTION: Check if controller prefabs exist
    void ControllerExists()
    {
        // Find all current game objects with target tag name
        Controllers = GameObject.FindGameObjectsWithTag(tagName);

        // If the array is not empty, then hide all the game objects in it
        if (Controllers.Length > 0)
        {
            // Define counter variable
            int counter = 0;

            foreach (GameObject Controller in Controllers)
            {
                //Controller.SetActive(false);

                // Save the position of each controller to POS array
                Pos[counter] = Controller.transform.position;
                counter += 1;
            }
        }

       
    }

    
}
