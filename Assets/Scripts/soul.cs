using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class soul : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField] GameObject select;
    [SerializeField] GameObject click;
    [SerializeField] Animator anim;
    int current;
    bool t;
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
        if (Input.GetKeyDown(KeyCode.DownArrow) && current < images.Length-1)
        {
            current++;
            Instantiate(select);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && current > 0)
        {
            current--;
            Instantiate(select);
        }
        bool e = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return);
        
        if (current == 0 && e)
        {
            StartCoroutine(ExampleCoroutine());
            
        }
        if (current == 1 && e)
        {
            Application.Quit();
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
