using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ResizeCamera : MonoBehaviour
{

    // Set this to the in-world distance between the left & right edges of your scene.
    public float sceneWidth = 10;

    Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update()
    {
        if(cam== null)
            cam = GetComponent<Camera>();

        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        cam.orthographicSize = desiredHalfHeight;
    }
}
