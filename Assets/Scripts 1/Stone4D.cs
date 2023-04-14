using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone4D : MonoBehaviour
{
    RaymarchCam Transform4D;
    Shape4D self;
    void Start()
    {
        Transform4D = FindObjectOfType<RaymarchCam>();
        self = GetComponent<Shape4D>();
        self.positionW = Transform4D._wPosition;
    }
    void Update()
    {
        transform.Translate(0, -3 * Time.deltaTime,0);
    }
}
