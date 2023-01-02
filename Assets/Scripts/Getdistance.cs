using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getdistance : MonoBehaviour
{
    [SerializeField] Transform point;
    public float gist()
    {
        return Vector3.Distance(transform.position, point.position);
    }

}
