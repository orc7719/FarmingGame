using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class Screenshotter
{
    [MenuItem("Screenshot/Take screenshot")]
    static void Screenshot()
    {
        ScreenCapture.CaptureScreenshot("test.png");
    }
}
