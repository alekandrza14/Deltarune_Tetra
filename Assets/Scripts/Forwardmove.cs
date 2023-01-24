using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forwardmove : MonoBehaviour
{
    
    void Update()
    {
        transform.Translate((-10*Time.deltaTime),0,0);
       Vector3 rot = transform.rotation.eulerAngles;
        rot.z += Random.Range(-2, 2);
        transform.rotation = Quaternion.Euler(rot);
    }
}
