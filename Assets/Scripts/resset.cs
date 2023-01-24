using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resset : MonoBehaviour
{
    public void Restart()
    {
        Settings.Player.Curent_Hero_healf = Settings.Player.Hero_healf;
        soul.tp = 0;
        SceneManager.LoadScene("Hyper_spamton_tutorial");
    }
}
