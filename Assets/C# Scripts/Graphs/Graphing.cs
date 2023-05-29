using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

// Goal: Spawn 5 circle sprites on the display, equally spaced out on the canvas

// To-do: > Incoorperate yMin into graph > Seperate classes for data transfer > Code cleanup

public class Graphing : MonoBehaviour
{
    [SerializeField] private GameObject CircleSprite;
    [SerializeField] private Canvas displayCanvas;
    private float[] xPoints;
    private float[] yPoints;
    private GameObject[] gameObjects;
    private GameObject[] lineObjects;

    int numPoints = 31 - 1; // n - 1 points will be spawned
    int sampleNum = 30;
    int setPWM = 15;

    // Define the max/min y-values of the display canvas
    float maxY = 5.0f; // Voltage
    float minY = 0.0f; // Voltage

    public float width;
    private float height;

    // Define Slider object for D2
    public Slider d2Slider;
    private float[] yAxis;
    //int numPoints = 6 - 1; // n - 1 points will be spawned

    // Start is called before the first frame update
    void Start()
    {

        yAxis = new float[numPoints];
        float width = displayCanvas.GetComponent<RectTransform>().rect.width;
        float height = displayCanvas.GetComponent<RectTransform>().rect.height;

        float xPos = 0.0f;
        float yPos = 0.0f;

        GameObject lastPointObject = null;

        for (int i = 0; i <= numPoints; i++) {

            GameObject SpawnedSprite = Instantiate(CircleSprite, new Vector3(xPos, yPos, 0), Quaternion.identity);
            SpawnedSprite.transform.SetParent(displayCanvas.transform, false);
            float widthSpacing = width / numPoints;
            float heightSpacing = height / numPoints;
            xPos += widthSpacing;
            yPos += heightSpacing;

            if (lastPointObject != null) {
                lineConnection(lastPointObject.GetComponent<RectTransform>().anchoredPosition, SpawnedSprite.GetComponent<RectTransform>().anchoredPosition);
            }

            lastPointObject = SpawnedSprite;

        }
    }

    // Update is called once per frame
    void Update()
    {
        // Create a function in which an array of 0-5V is written for n-samples

        //int numHigh = (numPoints+1) - setPWM;
        setPWM = (int) d2Slider.value;
        int numHigh = setPWM;


        for (int i = 0; i < numHigh; i++) {
            Debug.Log("5V");
            yPoints[i] = 5.0f;
        }

        for (int i = numHigh; i < numPoints; i++) {
            Debug.Log("0V");
            yPoints[i] = 0.0f;
        }

        //graphPoints(xPoints, yPoints, gameObjects);

        //Debug.Log("Length of y set: " + yPoints.Length + " and length of gameO: " + gameObjects.Length);
        
    }

    // Draws a line from each point on the graph.
    private void lineConnection(Vector3 point1, Vector3 point2) {
        GameObject lineImage = new GameObject("dotConnection", typeof(Image));
        lineImage.transform.SetParent(displayCanvas.transform, false);
        RectTransform imageRectTransform = lineImage.GetComponent<RectTransform>();
        Vector3 dir = (point2 - point1).normalized;
        float distance = Vector3.Distance(point1, point2);
        imageRectTransform.anchorMin = new Vector2(0.0f, 0.0f);
        imageRectTransform.anchorMax = new Vector2(0.0f, 0.0f);
        imageRectTransform.sizeDelta = new Vector2(distance, 0.02f);
        imageRectTransform.anchoredPosition = point1 + dir * distance * 0.5f;
        imageRectTransform.localEulerAngles = new Vector3(0.0f, 0.0f, UtilsClass.GetAngleFromVectorFloat(dir));
    }

}
