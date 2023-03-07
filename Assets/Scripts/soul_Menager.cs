using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class soul_Menager : MonoBehaviour
{
   // static public int damege = 1;
    [SerializeField] Image[] images;
    [SerializeField] GameObject select;
    [SerializeField] GameObject click;
    [SerializeField] GameObject[] act;
    [SerializeField] dialog_menager ac;
    public string[] strings_dialog_1;
    public string[] strings_dialog_2;
    [Multiline(4)] public string[] strings_dialog_3;
    public int current = -1;
    [SerializeField] public selects select_act;
    bool t;

    public void Check()
    {
        ac.strings_dialog = strings_dialog_3;

        ac.reset();
        current = -1;
        select_act = selects.none;
        foreach (GameObject i in act)
        {


            i.SetActive(false);

        }
    }
    public void hit(Getdistance i)
    {
        int d = (int)(i.gist() * 2);
        int da = (1000 - d);
        Debug.Log(da);
        if (da > 0) Hyper_Spamton_manager.damege = da; else Hyper_Spamton_manager.damege = 0;
        Hyper_Spamton_manager.current_hp_hs -= Hyper_Spamton_manager.damege;
        Debug.Log(Hyper_Spamton_manager.current_hp_hs);
    }
    public void hit2(Getdistance i)
    {
        if (Hyper_Spamton_manager.current_hp_hs <= 0)
        {
            Encoder.phase = 2;
        }
        int d = (int)(i.gist() * 12);
        int da = (6000 - d);
        Debug.Log(da);
        if (da > 0) Hyper_Spamton_manager.damege = da; else Hyper_Spamton_manager.damege = 0;
        Hyper_Spamton_manager.current_hp_hs -= Hyper_Spamton_manager.damege;

        Debug.Log(Hyper_Spamton_manager.current_hp_hs);


    }
    public void Go()
    {
        ac.strings_dialog = strings_dialog_1;

        ac.reset();
        current = -1;
        select_act = selects.none;
        foreach (GameObject i in act)
        {


            i.SetActive(false);

        }
    }
    public void Do()
    {
        ac.strings_dialog = strings_dialog_1;
        int a = 0;
        ac.reset();
        current = 5;
        select_act = selects.attack;
        foreach (GameObject i in act)
        {

            if (a == current)
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
            a++;

        }
    }
    public void Do1()
    {
        ac.strings_dialog = strings_dialog_1;
        int a = 0;
        ac.reset();
        current = 6;
        select_act = selects.supernova;
        foreach (GameObject i in act)
        {

            if (a == current)
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
            a++;

        }
    }

    void InputKey()
    {
        
        bool e = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return);
        bool m = Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);

        int a = 0;
        
        if (current >= 0)
        {
            ac.strings_dialog = strings_dialog_1;
            ac.reset();
            
        
        foreach (GameObject i in act)
            {

                if (a == current)
                {
                    i.SetActive(true);
                }
                else
                {
                    i.SetActive(false);
                }
                a++;

            }
            switch (current)
            {


                case 0:
                    select_act = selects.enemyes;
                    break;
                case 1:
                    select_act = selects.act;
                    break;
                case 2:
                    select_act = selects.item;
                    break;
                case 3:
                    select_act = selects.spare;
                    break;
                case 4:
                    select_act = selects.shild;
                    break;
                case 5:
                    select_act = selects.attack;
                    break;
            }

        }
        else
        {
            
        }
        if (m)
        {

            Instantiate(select);
            current = -1;
            ac.strings_dialog = strings_dialog_2;
            ac.reset();
            select_act = selects.none;
            foreach (GameObject i in act)
            {

                
                    i.SetActive(false);
                
            }
        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputKey();
        
        
    }
}
