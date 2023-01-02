using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum acting
{
    start_fight,none
}

public class dialog_menager : MonoBehaviour
{
    [SerializeField] Text txt;
    [Multiline(4)]
    [SerializeField] public string[] strings_dialog;

    [SerializeField] Animator anim;
    [SerializeField] bool unsig;
    [SerializeField] acting acting;
    string log;
    int a;
    float tic;
    int current_string;
    [SerializeField] GameObject sound_voise;
    bool act;
    bool end;
    float speed;
    int z;
    public void reset()
    {
        a = 0;

        log = "";
    }
    void InputKey()
    {

        bool e = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return); 
        bool m = Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);

        if (acting == acting.start_fight)
        {


            if (!act && e)
            {
                act = !act;
                log = "";
                z = 0;
            }
            if (e)
            {
                z++;
            }
            if (z >= 2)
            {

                if (current_string < strings_dialog.Length - 1)
                {
                    // anim.Play("cutscene_end");

                    current_string++;
                    act = false;
                    a = 0;

                    z = 0;
                }
                else if (current_string == strings_dialog.Length - 1)
                {
                    // anim.Play("cutscene_end");

                    Debug.Log("end");
                    end = true;
                    act = false;
                    current_string = -1;
                    if (!unsig) anim.Play("sig");
                    gameObject.SetActive(false);
                    if (end)
                    {
                        SceneManager.LoadScene("Hyper_spamton_tutorial");
                    }
                    z = 0;
                }
                else if (current_string > strings_dialog.Length - 1)
                {
                    Debug.Log("end");
                    end = true;
                    act = false;
                    current_string = -1;
                    if (!unsig) anim.Play("sig");
                    gameObject.SetActive(false);
                    if (end)
                    {
                        SceneManager.LoadScene("Hyper_spamton_tutorial");
                    }
                    z = 0;

                }
            }



            if (true) if (act)
                {
                    actor();
                    // StartCoroutine(DialogCoroutine());
                }
            if (m)
            {
                log = strings_dialog[current_string];
                //  current_string++;
                a = strings_dialog[current_string].Length;
                act = false;
                txt.text = log;
            }
        }
        else if(acting == acting.none)
        {
            txt.text = log;
            tic += 1f /(30f / speed);
            if (tic > 0.1 && !end)
            {

                if (strings_dialog[0].Length > a)
                {
                    log += strings_dialog[0][a];
                    Instantiate(sound_voise);
                }
                a++;

                if (!unsig) anim.Play("a");
                tic = 0;
            }
        }

    }
    bool ifer()
    {
        if (current_string > strings_dialog.Length-1)
        {
            Debug.Log("end");
            end = true;
            act = false;
            current_string = -1;
            if (acting == acting.start_fight) SceneManager.LoadScene("Hyper_spamton_tutorial");
            if (!unsig) anim.Play("sig");
            gameObject.SetActive(false);
            return false;
        }
       if(!end) if (a > strings_dialog[current_string].Length-1)
        {
            current_string++;
            act = false;
            a = -1;
            return false;
        }
        
        return true;
    }
    void actor()
    {
        txt.text = log;
        tic += 1f / (30f/ speed);
        if (tic > 0.1 && !end)
        {

            if (ifer() && !end)
            {
                log += strings_dialog[current_string][a];
                Instantiate(sound_voise);
            }
            a++;

            if (!unsig) anim.Play("a");
            tic = 0;
        }



    }
  // IEnumerator DialogCoroutine()
  // {
  //     
  //
  //
  //
  //     
  //
  //    
  //    // yield return new WaitForSeconds(0.1f);
  //    // a++;
  //    // if (current_string < strings_dialog.Length-1) if (a< strings_dialog[current_string].Length-1) log += strings_dialog[current_string][a]; else { a = 0; current_string++;act = false; }
  //    //
  //    // txt.text = log;
  //    // yield return 0;
  //
  // }
    // Start is called before the first frame update
    void Start()
    {

       speed = Settings.Player.dialog_speed;
    }

    // Update is called once per frame
    void Update()
    {
        InputKey();
    }
}
