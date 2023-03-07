using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encoder : MonoBehaviour
{
   static public byte phase = 0;
    static public bool debug;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip_phase_2;
    // Start is called before the first frame update
    void Start()
    {
        Hyper_Spamton_manager.current_hp_hs = Settings.Player.Hyper_spamton_healf;
        phase = 1;
        soul.items = 19;
        if (Application.isEditor)
        {
            debug = true;
        }
    }
    private void Update()
    {
        if (phase == 2)
        {
            source.clip = clip_phase_2;
            source.Play();
            Hyper_Spamton_manager.current_hp_hs = Hyper_Spamton_manager.current_hp_ph2_hs;
            Settings.Player.Hyper_spamton_healf = Hyper_Spamton_manager.current_hp_ph2_hs;
            phase = 3;
        }

        bool e = Input.GetKeyDown(KeyCode.Alpha1) && debug;
        bool e1 = Input.GetKeyDown(KeyCode.Alpha2) && debug;
        if (e)
        {
            soul.tp = 101;
        }
        if (e1)
        {
             phase = 2;
        }
    }


}
