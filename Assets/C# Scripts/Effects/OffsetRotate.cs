using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetRotate : MonoBehaviour
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
        TargetObject.transform.Rotate(Vector3.forward * Time.deltaTime * RotationSpeed);
    }
}
