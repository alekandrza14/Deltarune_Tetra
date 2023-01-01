using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class soul_Menager : MonoBehaviour
{
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
