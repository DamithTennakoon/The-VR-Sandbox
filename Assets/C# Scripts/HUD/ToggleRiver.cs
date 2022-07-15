using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import UI tools
using UnityEngine.UI;

// Toggle on the Grand Canyones river

public class ToggleRiver : MonoBehaviour
{
    // Create toggle object
    public Toggle RiverToggle;

    // Create Game Object for the Grand Canyon river
    public GameObject GrandCanyonRiver;

    // Create a Vector 3 to store position of the river
    public Vector3 RiverPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate River Position
        RiverPosition = new Vector3(2.4f, 43.6f, -9f);

        // Spawn river
        GrandCanyonRiver = Instantiate(GrandCanyonRiver, RiverPosition, Quaternion.identity);

        // De-render the river
        GrandCanyonRiver.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Set River as ACTIVE if toggle is switched on
        if (RiverToggle.GetComponent<Toggle>().isOn)
        {
            GrandCanyonRiver.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            GrandCanyonRiver.GetComponent<Renderer>().enabled = false;
        }
    }
}
