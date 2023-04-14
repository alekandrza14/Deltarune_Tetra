using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop4D : MonoBehaviour
{
    RaymarchCam Transform4D;
    Shape4D self;
    void Start()
    {
        Transform4D = FindObjectOfType<RaymarchCam>();
        self = GetComponent<Shape4D>();
    }
    void Update()
    {
        self.positionW = Transform4D._wPosition;
    }
}
