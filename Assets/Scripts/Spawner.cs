using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Spawn/RealTimeCountSpawner")]
public class Spawner : MonoBehaviour
{
    [Header("Count spawn")]
    [SerializeField]public int count;
    [Header("GameObject")]
    [SerializeField] GameObject something;
    decimal spawned;
    void FixedUpdate()
    {
        if (spawned < count)
        {
            spawned++;
            Instantiate(something,transform.position,transform.rotation);
        }
        if (count == 0)
        {
            spawned = 0;
        }
    }
}
