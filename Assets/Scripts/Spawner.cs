using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Spawn/RealTimeCountSpawner")]
public class Spawner : MonoBehaviour
{
    [Header("Count spawn")]
    [SerializeField] public int count;
    [SerializeField] public float timer;
    [Header("GameObject")]
    [SerializeField] GameObject something;
    decimal spawned;
    bool tr;
    void FixedUpdate()
    {
        if (spawned < count && !tr)
        {
            spawned++;
            Instantiate(something,transform.position,transform.rotation);
            StartCoroutine(RIG());
        }
        if (count == 0)
        {
            spawned = 0;
        }
    }
    IEnumerator RIG()
    {
        //Print the time of when the function is first called.
      //  Debug.Log("Started Coroutine at timestamp : " + Time.time);

      //  ScreenCapture.CaptureScreenshot("C:/Unauticna Multiverse/Screenshot" + Random.Range(0, int.MaxValue) + ".png", 1);
       

        tr = !tr;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timer);
        tr = !tr;

      //  Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
}
