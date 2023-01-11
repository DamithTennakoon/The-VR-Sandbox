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

    // Start is called before the first frame update
    void Start()
    {

        xPoints = new float[numPoints + 1];
        yPoints = new float[numPoints + 1];
        width = displayCanvas.GetComponent<RectTransform>().rect.width;
        height = displayCanvas.GetComponent<RectTransform>().rect.height;
        gameObjects = new GameObject[numPoints + 1];
        lineObjects = new GameObject[numPoints];

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

            gameObjects[i] = SpawnedSprite;

            //SpawnedSprite.GetComponent<RectTransform>().anchoredPosition = new Vector3(0.02f, 0.02f, 0.0f);

        }

        lineObjects = GameObject.FindGameObjectsWithTag("Graph Lines");
        Debug.Log("LOOOOOOOOOOOOOOOL: " + lineObjects[3].GetComponent<RectTransform>().anchoredPosition.x);
        Debug.Log(lineObjects.Length);
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

        graphPoints(xPoints, yPoints, gameObjects);

        //Debug.Log("Length of y set: " + yPoints.Length + " and length of gameO: " + gameObjects.Length);
    }

    // Draws a line from each point on the graph.
    private void lineConnection(Vector3 point1, Vector3 point2) {

        GameObject lineImage = new GameObject("dotConnection", typeof(Image));
        lineImage.transform.SetParent(displayCanvas.transform, false);
        RectTransform imageRectTransform = lineImage.GetComponent<RectTransform>();
        Vector3 dir = (point2 - point1).normalized; //*
        float distance = Vector3.Distance(point1, point2); //*
        imageRectTransform.anchorMin = new Vector2(0.0f, 0.0f);
        imageRectTransform.anchorMax = new Vector2(0.0f, 0.0f);
        imageRectTransform.sizeDelta = new Vector2(distance, 0.02f); //*
        imageRectTransform.anchoredPosition = point1 + dir * distance * 0.5f; //*
        imageRectTransform.localEulerAngles = new Vector3(0.0f, 0.0f, UtilsClass.GetAngleFromVectorFloat(dir)); //*
        lineImage.tag = "Graph Lines";
    }

    // Convert an input value to fit in the display canvas - for the y-axis
    private float convertValue(float inputValue) {

        float outputValue = 0.0f; // Initialize output variable
        outputValue = (inputValue / maxY) * height; // Conversion factor
        Debug.Log("Voltage:" + inputValue);
        return outputValue;
    }

    // Convert array into points on the display and draw lines between points
    private void graphPoints(float[] xData, float[] yData, GameObject[] objectsArray) {

        for (int j = 0; j < xData.Length; j++) {
            xData[j] = (j / xData.Length) * width; // Iteration converted to x-coordinate on display canvas
            yData[j] = convertValue(yData[j]); // Votlage value converted to y-coordinate on display canvas
            Debug.Log("width: " + width);

            if (j != 0)
            {
                xData[j] = xData[j - 1] + (width / numPoints);
            }
            else {
                xData[j] = 0.0f;
            }
        }

        Debug.Log("-----BREAK");

        // Plot the data on the display canvas
        GameObject lastSpawnedObject = null;

        for (int i = 0; i < objectsArray.Length; i++) {

            //GameObject SpawnedSprite = Instantiate(CircleSprite, new Vector3(xData[i], yData[i], 0), Quaternion.identity);
            //SpawnedSprite.transform.SetParent(displayCanvas.transform, false);

            objectsArray[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(xData[i], yData[i], 0.0f);
            //Debug.Log(gameObjects[i].GetComponent<RectTransform>().anchoredPosition);

            /*
            if (lastSpawnedObject != null)
            {
                lineConnection(lastSpawnedObject.GetComponent<RectTransform>().anchoredPosition, SpawnedSprite.GetComponent<RectTransform>().anchoredPosition);
            }*/

            //lastSpawnedObject = SpawnedSprite;

        }

        // Update the positions of the line objects
        changedLineConnection(xData, yData, gameObjects, lineObjects);

    }

    // Update the position of the generated lines
    private void changedLineConnection(float[] xPoints, float[] yPoints, GameObject[] points, GameObject[] lines)
    {
        GameObject prevPointObject = null;

        for (int i = 0; i <= numPoints; i++) {
            //RectTransform lineRectTranform = lines[i].GetComponent<RectTransform>();

            //Vector3 point1 = prevPointObject.GetComponent<RectTransform>().anchoredPosition;
            //Vector3 point2 = points[i].GetComponent<RectTransform>().anchoredPosition;

            if (prevPointObject != null) {
                Vector3 point1 = prevPointObject.GetComponent<RectTransform>().anchoredPosition;
                Vector3 point2 = points[i].GetComponent<RectTransform>().anchoredPosition;

                Vector3 dir = (point2 - point1).normalized; //*
                float distance = Vector3.Distance(point1, point2); //*

                
                lines[i-1].GetComponent<RectTransform>().sizeDelta = new Vector2(distance, 0.02f); //*
                lines[i-1].GetComponent<RectTransform>().anchoredPosition = point1 + dir * distance * 0.5f; //*
                lines[i-1].GetComponent<RectTransform>().localEulerAngles = new Vector3(0.0f, 0.0f, UtilsClass.GetAngleFromVectorFloat(dir)); //*
            }

            prevPointObject = points[i];
        }

    }

}
