using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum selects
{
    menu, enemyes, item, act, shild, spare, none
}

public class soul : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField] GameObject select;
    [SerializeField] GameObject click;
    [SerializeField] Animator anim;
    [SerializeField] acts ac;
    [SerializeField] Animator anim2;
    [SerializeField] Animator anim_panel;
    [SerializeField] selects select_type;
    [SerializeField] soul_Menager sm;
    [SerializeField] int scale = 0;
    [SerializeField] bool blok_updown;
    [SerializeField] bool flip_leftright;
    int current;
    bool t;
    IEnumerator ExampleCoroutine2()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);


       ac.fight = true;

        anim.SetBool("fight", ac.fight);

        anim_panel.Play("hide");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(7f);

        //  SceneManager.LoadScene("game");
        ac.fight = false;
        anim.SetBool("fight", ac.fight);
        anim_panel.Play("show");
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        


            Instantiate(click);
            anim.Play("Spamton_out");
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("game");

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        
    }
    void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && current < images.Length - 1 && !blok_updown)
        {
            current++;
            Instantiate(select);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && current > 0 && !blok_updown)
        {
            current--;
            Instantiate(select);
        }
        if (!flip_leftright)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && current - scale < images.Length - 1)
            {
                current -= scale;
                Instantiate(select);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && current - scale < images.Length - 1)
            {
                current -= scale;
                Instantiate(select);
            }
        }
        if (!flip_leftright)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && current + scale > 0)
            {
                current += scale;
                Instantiate(select);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && current + scale > 0)
            {
                current += scale;
                Instantiate(select);
            }
        }
        bool e = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return);
        if (select_type == selects.menu)
        {
            if (current == 0 && e)
            {
                StartCoroutine(ExampleCoroutine());

            }
            if (current == 1 && e)
            {
                Application.Quit();
            }
        }
    else  if(sm.select_act == select_type)  switch (select_type)
        {

            case selects.menu:

                if (current == 0 && e)
                {
                    StartCoroutine(ExampleCoroutine());

                }
                if (current == 1 && e)
                {
                    Application.Quit();
                }
                break;

            case selects.enemyes:

                if (e)
                {
                        ac.end_act();
                        sm.Go();
                    }

                break;
            case selects.act:

                    if (current == 0 && e)
                    {
                        sm.Check();

                    }

                    break;
                case selects.item:



                    break;
                case selects.shild:
                    ac.end_act();
                    sm.Go();


                    break;
                case selects.spare:
                    if (current == 0 && e)
                    {
                        ac.end_act();
                        sm.Go();
                    }
                    if (current == 1 && e)
                    {
                        ac.end_act();
                        sm.Go();
                    }


                    break;
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
        int a =0;
        if (current > images.Length - 1)
        {
            current = 0;
        }
        if (current < 0)
        {
            current = 0;
        }
        foreach (Image i in images)
        {
            
            if (a == current)
            {
                i.color = new Color(1, 1, 1, 1);
            }
            else
            {
                i.color = new Color(0, 0, 0, 0);
            }
            a++;

        }
        
    }
}
