using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Goal: Manually check the states of each drop zone mesh renderer

public class WiringLED : MonoBehaviour
{
    // Define Game Objects for each wire and its corresponding points
    public GameObject[] wires;

    // Define states of each wire
    private int[] states;

    // Define Game Object for LED filament
    public GameObject Filament;

    // Define Material objects for on/off states of LED
    public Material FilamentOn, FilamentOff;

    // Define Game object array to store the lines of wires
    public GameObject[] lineRender;

    // Define Material objects to store connected/disconneted line materials
    public Material ConnectedMat, DisconnectedMat;

    // Define bolean to save state of connections
    private bool connecionState;

    // Start is called before the first frame update
    void Start()
    {
        // Set filament off to when the game starts
        Filament.GetComponent<MeshRenderer>().material = FilamentOff;

        // Initialize states array to 0
        states = new int[wires.Length];

        for (int i = 0; i < wires.Length; i++)
        {
            states[i] = 0;
        }

        // Initialize wires disconnected states to corresponding material
        for (int l = 0; l < lineRender.Length; l++)
        {
            lineRender[l].GetComponent<LineRenderer>().material = DisconnectedMat;
        }

        // Initialize connection state to false
        connecionState = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check the states of the mesh renderes of each object
        CheckRenderer(wires);

        // Change the filament material if the circuit is closed
        if (SumArray(states) >= wires.Length)
        {
            Filament.GetComponent<MeshRenderer>().material = FilamentOn;

            // Change the state of connection to true
            connecionState = true;
        }
        else
        {
            Filament.GetComponent<MeshRenderer>().material = FilamentOff;

            // Change the state of connection to false
            connecionState = false;
        }

        // Change state of material based on conncetion state
        wireMaterial(connecionState, lineRender);
    }

    // Create a function that checks the state of an objects renderer
    private void CheckRenderer(GameObject[] ArrayObjects)
    {
        for (int j = 0; j < ArrayObjects.Length; j++)
        {
            if (ArrayObjects[j].GetComponent<MeshRenderer>().enabled == false)
            {
                states[j] = 1;
            }
            else
            {
                states[j] = 0;
            }
        }
    }

    // Create a function that returns the sum of an array
    private int SumArray(int[] ArrayInts)
    {
        int sum = 0;
        for (int k = 0; k < ArrayInts.Length; k++)
        {
            sum += ArrayInts[k];
        }

        return sum;
    }

    // Function: Change material of wires when connected/disconnected
    private void wireMaterial(bool state, GameObject[] wireArray)
    {
        if (state)
        {
            for (int m = 0; m < wireArray.Length; m++)
            {
                wireArray[m].GetComponent<LineRenderer>().material = ConnectedMat;
            }
        }
        else
        {
            for (int o = 0; o < wireArray.Length; o++)
            {
                wireArray[o].GetComponent<LineRenderer>().material = DisconnectedMat;
            }
        }
    }

    /*
    IEnumerator Test()
    {
        for (int i = 0; i <= 6; i++)
        {
            Debug.Log(i);
            yield return null;
        }
    }
    */
}
