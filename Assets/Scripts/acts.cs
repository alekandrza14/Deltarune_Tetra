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

    public IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(0.5f);
        sm.Go();
        fight = true;
        tp.attacktpup();
        anim.SetBool("fight", fight);

        anim_panel.Play("hide");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(7f);

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

        anim_panel.Play("hide");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(7f);

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


        if (Input.GetKeyDown(KeyCode.RightArrow) && current < images.Length - 1 && !fight && sm.current == -1)
        {
            Instantiate(select);
            current++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && current > 0 && !fight && sm.current == -1)
        {
            Instantiate(select);
            current--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && current < images.Length - 1 && !fight && sm.current == -1)
        {
            Instantiate(select);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && current > 0 && !fight && sm.current == -1)
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
