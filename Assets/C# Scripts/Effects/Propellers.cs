using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Code Objective: Control the rotation of objects. Be able to control the
// speed of the rotaion. Should be applicable to any object.
public class Propellers : MonoBehaviour
{
    // Access the vector of object
    [SerializeField] private Vector3 ObjectRotation;

    // Define variable to control rotation speed
    [SerializeField] private float RotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object
        transform.Rotate(ObjectRotation * RotationSpeed * Time.deltaTime); 
    }
}
