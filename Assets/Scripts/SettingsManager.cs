using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using System.Collections;

public class SettingsManager : MonoBehaviour {
 
    public bool fullScreen = false;
    private static string fullScreenKey = "Full Screen";
    public int minDisplaySize = 384;
    private static int monitorWidth;
    private static int monitorHeight;
   
    #if UNITY_STANDALONE_WIN
   
    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    private static extern bool SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
   
    [DllImport("user32.dll", EntryPoint = "FindWindow")]
    public static extern IntPtr FindWindow(string className, string windowName);
   
    public static IEnumerator SetWindowPosition(int x, int y) {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        SetWindowPos(FindWindow(null, Application.productName), 0, x, y, 0, 0, 5);
    }
   
    #endif
   
    void Start() {
        monitorWidth = Screen.resolutions[Screen.resolutions.Length - 1].width;
        monitorHeight = Screen.resolutions[Screen.resolutions.Length - 1].height;
        CheckAndSet();
    }
   
    private void CheckAndSet() {
       
            SetWindowed();
        
    }
   
    public void SetFullScreen() {
        Screen.SetResolution(monitorWidth, monitorHeight, true);
        fullScreen = true;
        PlayerPrefs.SetInt(fullScreenKey, 1);
        PlayerPrefs.Save();
    }
    public void RandomShake()
    {
        int randX = UnityEngine.Random.Range(-10,10);
#if UNITY_STANDALONE_WIN
       
        StartCoroutine(SetWindowPosition((int)getpos().x + randX, (int)getpos().y));

#endif
    }
    public Vector2 getpos()
    {
#if UNITY_STANDALONE_WIN
        int multiplier = 1;
        if (monitorWidth >= monitorHeight)
        {
            multiplier = monitorHeight / minDisplaySize;
            if ((monitorHeight % minDisplaySize) == 0)
            {
                multiplier--;
            }
        }
        else
        {
            multiplier = monitorWidth / minDisplaySize;
            if ((monitorWidth % minDisplaySize) == 0)
            {
                multiplier--;
            }
        }
        int size = minDisplaySize * multiplier;
        if (size < minDisplaySize)
        {
            size = minDisplaySize;
        }
        int x = monitorWidth / 2;
        x -= size / 2;
        int y = monitorHeight / 2;
        y -= size / 2;
#endif
        return new Vector2(x,y);
    }

    public void Update()
    {
        RandomShake();
    }
    public void SetWindowed() {
        SetWindowResolution();
        fullScreen = false;
        PlayerPrefs.SetInt(fullScreenKey, 0);
        PlayerPrefs.Save();
    }
   
    private void SetWindowResolution() {
        int multiplier = 1;
        if (monitorWidth >= monitorHeight) {
            multiplier = monitorHeight / minDisplaySize;
            if ((monitorHeight % minDisplaySize) == 0) {
                multiplier--;
            }
        } else {
            multiplier = monitorWidth / minDisplaySize;
            if ((monitorWidth % minDisplaySize) == 0) {
                multiplier--;
            }
        }
        int size = minDisplaySize * multiplier;
        if (size < minDisplaySize) {
            size = minDisplaySize;
        }
        Screen.SetResolution(1020, 768, false);
       
        #if UNITY_STANDALONE_WIN
       
        int x = monitorWidth / 2;
        x -= size / 2;
        int y = monitorHeight / 2;
        y -= size / 2;
        StartCoroutine(SetWindowPosition(x, y));
       
        #endif
    }
}
 