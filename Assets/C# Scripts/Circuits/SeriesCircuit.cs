using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;

/* Goal: Change the state of an object based on the states of the drop zone
 * triggers. In general, for a series circuit to be closed, the AND of all 
 * connections must be HIGH/TRUE.
 */

public class SeriesCircuit : MonoBehaviour
{
    // Define a Game Object array to store drop zone objects
    public GameObject[] dropZones;

    // Define a boolean array to store the stes of the drop zones
    private bool[] dropZoneStates;

    // Define private string variable to store the name of the wire tags
    private string wireTag = "SeriesConnection";

    // Define integer variable for a counter
    private int counter = 0;

    // Define interger variable to store the state of the SERIES circuit
    private int circuitState = 1;

    // Define Game Object for LED filament
    public GameObject Filament;

    // Define Material objects for on/off states of LED
    public Material FilamentOn, FilamentOff;

    // Start is called before the first frame update
    void Start()
    {
        /* Instantiate the number of elements in the states array based on the
         * total number of objects in the drop zones array. NOTE: Each index
         * number of the drop zones array corresponds to the states array.
         */
        dropZoneStates = new bool[dropZones.Length];
        Debug.Log(dropZoneStates.Length);

        for (int i = 0; i <= dropZones.Length; i++)
        {
            dropZoneStates[i] = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Check the state of each drop zone within the drop zone array
        if (dropZones[counter].GetComponent<MeshRenderer>().enabled == false)
        {
            dropZoneStates[counter] = true;
            //circuitState *= System.Convert.ToInt32(dropZoneStates[counter]);
            circuitState *= 1;
        }
        else
        {
            dropZoneStates[counter] = false;
            //circuitState *= System.Convert.ToInt32(dropZoneStates[counter]);
            circuitState *= 0;
        }

        if (counter >= dropZones.Length - 1)
        {
            CheckSeriesCircuit();

            // Reset counter
            counter = 0;
        }

        // Increment the counter
        counter++;
    }

    // Function: Light up LED
    private void CheckSeriesCircuit()
    {
        if (circuitState > 0)
        {
            Filament.GetComponent<MeshRenderer>().material = FilamentOn;
        }
        else
        {
            //Filament.GetComponent<MeshRenderer>().material = FilamentOff;
        }
    }
}

// Try adding the states and matching to length of array, else cheap way