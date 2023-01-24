using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("LogicTags/Tag Hero Hp")]
public class GetHeroHp : MonoBehaviour
{

    public Scrollbar scrlbr;

    void FixedUpdate()
    {
        if (GetComponent<Text>()) GetComponent<Text>().text = "HP " + Settings.Player.Curent_Hero_healf.ToString() + "/" + Settings.Player.Hero_healf.ToString();
        scrlbr.size = (float)(Settings.Player.Curent_Hero_healf) / (float)(Settings.Player.Hero_healf);
    }
}
