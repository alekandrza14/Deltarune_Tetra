using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog_menager : MonoBehaviour
{
    [SerializeField] Text txt;
    [Multiline(4)]
    [SerializeField] string[] strings_dialog;
    [SerializeField] Animator anim;
    string log;
    int a;
    float tic;
    int current_string;
    [SerializeField] GameObject sound_voise;
    bool act;
    bool end;
    void InputKey()
    {
        
        bool e = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return);


        if (!act && e)
        {
            act = !act;
            log = "";
        }
        
        if (act)
        {
            actor();
           // StartCoroutine(DialogCoroutine());
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
            anim.Play("sig");
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
        tic += Time.deltaTime;
        if (tic > 0.1)
        {
            
         if(ifer()&& !end)log += strings_dialog[current_string][a];
            Instantiate(sound_voise);
            a++;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        InputKey();
    }
}
