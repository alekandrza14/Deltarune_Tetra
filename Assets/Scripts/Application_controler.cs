using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unauticna;

namespace Unauticna
{

    public class Math
    {
        public static int booleanToIntegger(bool a)
        {
            int e = 0;
            if (a) e = 1;
            return e;
        }
    }
    
}

public class Application_controler : MonoBehaviour
{
    bool windowed;
    private void Awake()
    {
        Application.targetFrameRate = 30;
        windowed = 1 == PlayerPrefs.GetInt("Windowed", 1);
        Screen.SetResolution(1020, 768, !windowed, 15);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        { 
            windowed = !windowed; 
            PlayerPrefs.SetInt("Windowed", Math.booleanToIntegger( windowed));
            Screen.SetResolution(1020, 768, !windowed, 15);
        }
    }
}
