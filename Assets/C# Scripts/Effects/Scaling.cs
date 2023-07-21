using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    // Test
    Vector3 temp;
    Vector3 OriginalScale;

    // Create Exoloratory Object
    public ControllerData data;

    // Create float object to store distance
    private float distance;

    // Create a game object for target transform
    public GameObject Target;

    // Create float object to store angle;
    private float CurrentAngle;

    // Create float object to store initial angle difference
    private float PreviousAngle;

    // Define factor to control strength of scale
    private float ScaleFactor;

    // Start is called before the first frame update
    void Start()
    {
        distance = 1;

        OriginalScale = transform.localScale;

        CurrentAngle = 0;

        PreviousAngle = Vector3.Angle(Target.transform.position, data.Controller2 - data.Controller1);


        // Instantiate the scale factor
        ScaleFactor = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        temp = transform.localScale;
        temp.x += Time.deltaTime;
        transform.localScale =  temp;
        */
        distance = data.ScaleValue;

        bool test = true;
        // Check if the primary button is pressed
        if (data.PrimaryButtonValue)
        {
            // Scale object
            temp = OriginalScale;
            temp.x = temp.x + distance * ScaleFactor;
            temp.y = temp.y + distance * ScaleFactor;
            temp.z = temp.z + distance * ScaleFactor;
            transform.localScale = temp;

            // Compute the angle differnce
            CurrentAngle = Vector3.Angle(Target.transform.position, data.Controller2 - data.Controller1);

            if (CurrentAngle != PreviousAngle)
            {
                float AngleDiff = CurrentAngle - PreviousAngle;

                transform.Rotate(Vector3.up, AngleDiff);

                PreviousAngle = CurrentAngle;
            }
        }

        /*
        // Compute the angle differnce
        CurrentAngle = Vector3.Angle(Target.transform.position, data.Controller2 - data.Controller1);

        if (CurrentAngle != PreviousAngle)
        {
            float AngleDiff = CurrentAngle - PreviousAngle;

            transform.Rotate(Vector3.up, AngleDiff);

            PreviousAngle = CurrentAngle;
        }*/

        
        
    }
}
