using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum selects
{
    menu, enemyes, item, act, shild, spare, none, attack, supernova
}

public class soul : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField] GameObject select;
    [SerializeField] GameObject click;
    [SerializeField] Animator anim;
    [SerializeField] acts ac;
    [SerializeField] Animator anim2;
    [SerializeField] Animator anim3;
    [SerializeField] Animator anim_panel;
    [SerializeField] selects select_type;
    [SerializeField] soul_Menager sm;
    [SerializeField] int scale = 0;
    [SerializeField] bool blok_updown;
    [SerializeField] bool flip_leftright;
    [SerializeField] Getdistance get_dist;
    [SerializeField] Scrollbar tpbar;
    [SerializeField] Text txt;
    public static int tp = 0;
    public static int items = 19;
    int current;
    float tic = 0;
    bool t;
    public void attacktpup()
    {
        
        if (Hyper_Spamton_manager.damege >= 900)
        {


            if (tp < 100 - 5) tp += 1; else { tp = 100; }
            if (tp != 100) txt.text = tp.ToString(); else { txt.text = "max"; }
        }
        if (Hyper_Spamton_manager.damege >= 400)
        {


            if (tp < 100 - 1) tp += 1; else { tp = 100; }
            if (tp != 100) txt.text = tp.ToString(); else { txt.text = "max"; }
        }
        if (Hyper_Spamton_manager.damege >= 300)
        {


            if (tp < 100 - 1) tp += 1; else { tp = 100; }
            if (tp != 100) txt.text = tp.ToString(); else { txt.text = "max"; }
        }
        if (Hyper_Spamton_manager.damege >= 200)
        {


            if (tp < 100 - 1) tp += 1; else { tp = 100; }
            if (tp != 100) txt.text = tp.ToString(); else { txt.text = "max"; }
        }
        if (Hyper_Spamton_manager.damege >= 100)
        {


            if (tp < 100 - 1) tp += 1; else { tp = 100; }
            if (tp != 100) txt.text = tp.ToString(); else { txt.text = "max"; }
        }
        tpbar.size = (float)(tp) / 100;
    }
     IEnumerator ExampleCoroutine2()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);


       ac.fight = true;

        anim.SetBool("fight", ac.fight);

        anim_panel.Play("hide");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(7f);

        anim2.Play("Kriss_unshield");
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(Hyper_Spamton_manager.current_hp_hs);
        }
        bool s = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
        bool w = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        bool a = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
        bool d = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);
        if (s && current < images.Length - 1 && !blok_updown)
        {
            current++;
            Instantiate(select);
        }
        if (w && current > 0 && !blok_updown)
        {
            current--;
            Instantiate(select);
        }
        if (!flip_leftright)
        {
            if (a && current - scale < images.Length - 1)
            {
                current -= scale;
                Instantiate(select);
            }
        }
        else
        {
            if (d && current - scale < images.Length - 1)
            {
                current -= scale;
                Instantiate(select);
            }
        }
        if (!flip_leftright)
        {
            if (d && current + scale > 0)
            {
                current += scale;
                Instantiate(select);
            }
        }
        else
        {
            if (a && current + scale > 0)
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
                      //  ac.end_act();
                        sm.Do();
                       // sm.select_act = selects.attack;
                    }

                    break;
                case selects.attack:
                    anim3.Play("hit_bar_left_attack", 0);
                    if (t) { tic += Time.deltaTime;  }
                    if (true) if (!t) { anim3.Play("none", 1);}
                    if (e)
                    {
                        sm.hit(get_dist);
                        if (true)
                        {
                            if (true) t = true;

                            anim3.Play("hit_bar_end", 1);
                            anim2.Play("Kriss_attack");
                            ac.end_act_v2();

                            if (true) t = true;


                         
                            Debug.Log(get_dist.gist());
                        }
                        
                    }
                    if (tic >= 0.5) { sm.Go(); t = false; tic = 0;  }
                    break;
                case selects.supernova:
                    anim3.Play("hit_bar_left_attack", 0);
                    if (t) { tic += Time.deltaTime; }
                    if (true) if (!t) { anim3.Play("none", 1); }
                    if (e)
                    {
                        sm.hit2(get_dist);
                        if (true)
                        {
                            if (true) t = true;

                            anim3.Play("hit_bar_end", 1);
                            anim2.Play("Kriss_shield2");
                            ac.end_act_v2();

                            if (true) t = true;



                            Debug.Log(get_dist.gist());
                        }

                    }
                    if (tic >= 0.5) { sm.Go(); t = false; tic = 0; }
                    break;
                case selects.act:

                    if (current == 0 && e)
                    {
                        sm.Check();

                    }
                    if (current == 1 && e && soul.tp > 100)
                    {
                        soul.tp = 0;
                        if (tp != 100) txt.text = tp.ToString(); else { txt.text = "max"; }
                        tpbar.size = (float)(tp) / 100;
                        ac.Dodge();
                        sm.Go();
                    }
                    if (current == 2 && e && soul.tp > 100)
                    {
                        soul.tp = 0;
                        if (tp != 100) txt.text = tp.ToString(); else { txt.text = "max"; }
                        tpbar.size = (float)(tp) / 100;
                         sm.Do1(); 
                        
                    }
                    if (current == 4 && e && soul.tp > 25)
                    {
                        soul.tp -= 25;
                        if (tp != 100) txt.text = tp.ToString(); else { txt.text = "max"; }
                        tpbar.size = (float)(tp) / 100;
                        Settings.Player.Curent_Hero_healf = Settings.Player.Hero_healf;
                        ac.end_act();
                        sm.Go();
                    }
                    

                    break;
                case selects.item:

                    if (e && items >= 0)
                    {
                        Settings.Player.Curent_Hero_healf = Settings.Player.Hero_healf;
                        ac.end_act();
                        sm.Go();
                        items--;

                        txt.text = "Items : " + items.ToString();
                    }


                        break;
                case selects.shild:
                  if(tp < 100-16)  tp += 16; else { tp = 100; }
                  if(tp != 100)  txt.text = tp.ToString(); else { txt.text = "max"; }
                    tpbar.size = (float)(tp) / 100;
                    anim2.Play("Kriss_shield");
                    ac.end_act();
                    sm.Go();


                    break;
                case selects.spare:
                    if (current == 0 && e)
                    {
                        sm.Go();

                    }
                    if (current == 1 && e)
                    {
                        if (Hyper_Spamton_manager.current_hp_hs <= 0)
                        {
                            SceneManager.LoadScene("GameVin");
                        }
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
