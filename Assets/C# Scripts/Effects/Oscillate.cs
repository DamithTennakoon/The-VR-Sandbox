using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: Make objects oscillate up and down with sinusoidal motion


public class Oscillate : MonoBehaviour
{
    // Define float variable to control amplitude in the inspector
    public float Amp;

    // Define float variable to control frequency in the inspector
    public float Freq;

    // Define Vector 3 object to save objects inititial position
    Vector3 InitPos;

    // Start is called before the first frame update
    void Start()
    {
        // Extract initial position infomation of object
        InitPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Oscillate object using Sine function
        // Ensure to only move object on the y-axis
        transform.position = new Vector3(InitPos.x, Mathf.Sin(Time.deltaTime * Freq) * Amp + InitPos.y, InitPos.z);
        
    }
}
