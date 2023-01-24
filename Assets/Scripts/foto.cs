using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        ScreenCapture.CaptureScreenshot("C:/Unauticna Multiverse/Screenshot" + Random.Range(0, int.MaxValue) + ".png", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
