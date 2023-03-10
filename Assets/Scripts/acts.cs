using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class acts : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField] Sprite[] spites_on_select;
    [SerializeField] Sprite[] spites_not_select;
    [SerializeField] GameObject select;
    [SerializeField] GameObject click;
    [SerializeField] Animator anim;
    [SerializeField] Animator anim_panel;
    [SerializeField] Animator attacks_spamton;
    [SerializeField] string[] attacks_spamton_names;
    [SerializeField] string[] attacks_phase2_spamton_names;
    [SerializeField] int current_attack_spamton;
    [SerializeField] soul_Menager sm;
    [SerializeField] soul tp;
    [SerializeField] public bool fight = false;
    [SerializeField] bool acting = false;
    int current;
    bool t;

    void Awake()
    {
        anim.SetBool("fight", false);
    }
    public void end_act()
    {
        StartCoroutine(ExampleCoroutine());
    }
    public void end_act_v2()
    {
        StartCoroutine(ExampleCoroutine2());
    }
    public void Dodge()
    {
        current_attack_spamton++;
    }

    public IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(0.5f);
        sm.Go();
        fight = true;
        tp.attacktpup();
        anim.SetBool("fight", fight);
        if (attacks_spamton_names.Length > current_attack_spamton) { attacks_spamton.Play(attacks_spamton_names[current_attack_spamton], 1); }
        if (attacks_spamton_names.Length - 1 < current_attack_spamton) { current_attack_spamton = 0; }
        anim_panel.Play("hide");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(7f);

        current_attack_spamton++;
        //  SceneManager.LoadScene("game");
        fight = false;
        anim.SetBool("fight", fight);
        anim_panel.Play("show");
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
    public IEnumerator ExampleCoroutine2()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);


        fight = true;

        tp.attacktpup();
        anim.SetBool("fight", fight);
        if (Encoder.phase ==3)
        {
            attacks_spamton_names = attacks_phase2_spamton_names;
        }
        if (attacks_spamton_names.Length > current_attack_spamton) { attacks_spamton.Play(attacks_spamton_names[current_attack_spamton], 1); }
        if (attacks_spamton_names.Length-1 < current_attack_spamton) { current_attack_spamton = 0; }
            anim_panel.Play("hide");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(7f);
        current_attack_spamton++;
        //  SceneManager.LoadScene("game");
        fight = false;
        anim.SetBool("fight", fight);
        anim_panel.Play("show");
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
    void InputKey()
    {
        bool e = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return);
        bool s = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
        bool w = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        bool a = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
        bool d = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);

        if (d && current < images.Length - 1 && !fight && sm.current == -1)
        {
            Instantiate(select);
            current++;
        }
        if (a && current > 0 && !fight && sm.current == -1)
        {
            Instantiate(select);
            current--;
        }
        if (d && current < images.Length - 1 && !fight && sm.current == -1)
        {
            Instantiate(select);
        }
        if (a && current > 0 && !fight && sm.current == -1)
        {
            Instantiate(select);
        }

        //  bool e = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return);

        if (e && !fight)
        {
            Instantiate(click);
        }
        if (sm.current == -1)
        {
            acting = false;
        }

        if (e && !fight && !acting)
        {
            
            // StartCoroutine(ExampleCoroutine());
            sm.current = current;
            acting = true;
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
        foreach (Image i in images)
        {
            if (!fight)
            {


                if (a == current)
                {
                    i.sprite = spites_on_select[a];
                }
                else
                {
                    i.sprite = spites_not_select[a];
                }
            }
            else
            {
                i.sprite = spites_not_select[a];
            }
            a++;

        }
        
    }
}
