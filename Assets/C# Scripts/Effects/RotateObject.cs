using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Goal: Make objects rotate about the y-axis (purpose of effects)

public class RotateObject : MonoBehaviour
{
    // Define float variable to set speed of rotation
    public float RotationSpeed = 50.0f;

    // Define Game Object to be rotated
    public GameObject TargetObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetObject.transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
    }
}
