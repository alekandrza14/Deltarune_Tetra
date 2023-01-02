using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("LogicTags/Tag Hero Hp")]
public class GetHeroHp : MonoBehaviour
{

    void Awake()
    {
        if (GetComponent<Text>()) GetComponent<Text>().text ="HP "+ Settings.Player.Hero_healf.ToString() +"/" + Settings.Player.Hero_healf.ToString();
    }
}
