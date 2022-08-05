using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Goal: Render a line between two objects as input positions

public class LineGenerator : MonoBehaviour
{
    // Define Line Renderer object to attach in inspector
    public LineRenderer Wire;

    // Define objects 1 & 2 (start and end positions)
    public Transform StartPos, EndPos;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate the number of points within the line
        Wire.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the start and end positions of line based on object positions
        Wire.SetPosition(0, StartPos.position);
        Wire.SetPosition(1, EndPos.position);
    }
}
