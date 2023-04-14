using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resset : MonoBehaviour
{
   static public int scene;
    public void Restart()
    {
        Settings.Player.Curent_Hero_healf = Settings.Player.Hero_healf;
        soul.tp = 0;
        Encoder.phase = 0;
        SceneManager.LoadScene(scene);
    }
    public void Regame()
    {
        Settings.Player.Curent_Hero_healf = Settings.Player.Hero_healf;
        soul.tp = 0;

        Encoder.phase = 0;
        SceneManager.LoadScene("menu");
    }
}
