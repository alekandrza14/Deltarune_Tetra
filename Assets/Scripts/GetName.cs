using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("LogicTags/Tag \"Hero Name\"")]
public class GetName : MonoBehaviour
{

    void Awake()
    {
        if (GetComponent<Text>()) GetComponent<Text>().text = Settings.Player.name;
    }
}
