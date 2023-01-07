using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetDamege : MonoBehaviour
{

    void Update()
    {
       if(Hyper_Spamton_manager.damege > 0) if (GetComponent<TextMeshProUGUI>()) GetComponent<TextMeshProUGUI>().text = Hyper_Spamton_manager.damege.ToString(); 
            else { if (GetComponent<TextMeshProUGUI>()) GetComponent<TextMeshProUGUI>().text = "miss"; }
    }
}
