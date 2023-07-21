using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Import Scene Management library
using UnityEngine.SceneManagement;


/* NOTES:
 * Scene 0: Main (HUB)
 * Scene 1: Swiss National Park 
 */

public class SceneLoader : MonoBehaviour
{
    // Create function to switch to the "Swiss National Park" scene
    public void SwissNationalPark()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Create function to switch to the "The Grand Canyone" scene
    public void GrandCanyone()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // Create function to switch to the "Mechanical Engineering Lab" scene
    public void MechEngLab()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }

    // Create function to switch to the "Elecrtrical Engineering Lab" scene
    public void ElecEngLab()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    // Create funciton to switch back to the "HUB" scene
    public void HUB()
    {
        SceneManager.LoadScene(0);
    }
}
