using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Goal: Enable celestial bodies to orbit a large mass: create a solar system
 * using Newton's Law of Gravitation.
*/

public class SolarSystem : MonoBehaviour
{
    // CONSTANTS
    readonly float G = 0.000001f; // Gravitational constant

    // Define array variable to store all celestial objects
    GameObject[] celestialBodies;

    // Start is called before the first frame update
    void Start()
    {
        // Populate the array with all Game Objects that have the tag "Celestial"
        celestialBodies = GameObject.FindGameObjectsWithTag("Celestial");

        // Compute orbital velocity
        OrbitalVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        // Compute gravitaional forces
        ComputeGravity();

    }

    // FUNCTION: Calculate the force of gravity between all celestial bodies
    // excluding itself
    void ComputeGravity()
    {
        // Iterate through all objects and calcualte force of gravity
        // Nested foreach-loop to exclude computing gravity relative to self
        foreach (GameObject i in celestialBodies)
        {
            foreach (GameObject j in celestialBodies)
            {
                // Check if object is not equal to itself
                if (!i.Equals(j))
                {
                    // Store the mass of both bodies
                    float mass1 = i.GetComponent<Rigidbody>().mass;
                    float mass2 = j.GetComponent<Rigidbody>().mass;

                    // Compute the radial distance between the two bodies
                    float radius = Vector3.Distance(i.transform.position, j.transform.position);

                    // Add gravitational force to each celestial body (Newston's Law of Gravitation)
                    i.GetComponent<Rigidbody>().AddForce((j.transform.position - i.transform.position).normalized *
                        (G * (mass1 * mass2) / (radius * radius)));

                }
            }
        }
    }

    // FUNCTION: Calcualte the orbital speed of each celestial body
    // exlcuding itself
    void OrbitalVelocity()
    {
        foreach (GameObject i in celestialBodies)
        {
            foreach (GameObject j in celestialBodies)
            {
                // Check if object is not equal to itself
                if (!i.Equals(j))
                {
                    // Store the mass of the second celestial body
                    float mass2 = j.GetComponent<Rigidbody>().mass;

                    // Compute and store the radial distance between both bodies
                    float radius = Vector3.Distance(i.transform.position, j.transform.position);

                    // Update the trasnform of the first planet while rotating its
                    // transform to ensure the forward vectors points towards
                    // the second planet
                    i.transform.LookAt(j.transform);

                    // Compute and add Circular Orbital Velocity to each planet
                    i.GetComponent<Rigidbody>().velocity += i.transform.right * Mathf.Sqrt((G * mass2) / radius);
                }
            }
        }
    }
}
