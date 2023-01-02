using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("LogicTags/Tag-Sound")]
public class Sound_fragment : MonoBehaviour
{
    public IEnumerator DestLoad()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }
    void Start()
    {
        StartCoroutine(DestLoad());
    }

}
