using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("LogicTags/Tag Hyper Spamton Hp")]
public class GetHyperSpamtonHp : MonoBehaviour
{

    public Scrollbar scrlbr;
    public Text txt;
    public Text txt2;

    void FixedUpdate()
    {
        if (Hyper_Spamton_manager.current_hp_hs >= 0)
        { 
            scrlbr.size = (((float)Hyper_Spamton_manager.current_hp_hs / (float)Settings.Player.Hyper_spamton_healf));
            txt.text = (int)(scrlbr.size * 100) + "%";
            txt2.text = (int)(scrlbr.size * 100) + "%";
        }
        else
        {
            txt.text = "dead";
            txt2.text = "dead";
            scrlbr.size = 0;
        }
        
    }
}
