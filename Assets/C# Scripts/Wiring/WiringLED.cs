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
        }
        else
        {
            Filament.GetComponent<MeshRenderer>().material = FilamentOff;
        }
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
