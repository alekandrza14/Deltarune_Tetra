using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Heart_hero : MonoBehaviour
{

    [SerializeField]public acts ac;
    public Animator canvas_animator;
   [HideInInspector] public bool rig;
    public SpriteRenderer heart;
    public Sprite[] sprites;
    [HideInInspector] public bool is4Dhide;
    [HideInInspector] public bool on4Dhide;
    [SerializeField] public bool demo;
    [SerializeField] public Text tp;
    RaymarchCam Transform4D;
    void Start()
    {
        Transform4D = FindObjectOfType<RaymarchCam>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.PageDown))
        {
            Transform4D._wPosition -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.PageUp))
        {
            Transform4D._wPosition += Time.deltaTime;
        }
        Rigidbody r = GetComponent<Rigidbody>();
        if (ac)
        {
            if (ac.fight && !r.isKinematic)
            {
                Vector3 vel = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 8 * Time.deltaTime;
                r.MovePosition(transform.position + vel);
                bool e = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return);
                if (e && !on4Dhide)
                {
                    is4Dhide = !is4Dhide;
                    on4Dhide = true;
                    StartCoroutine(hide());
                }
                if (is4Dhide)
                {
                    heart.sprite = sprites[1];
                }
                if (!is4Dhide)
                {
                    heart.sprite = sprites[0];
                }
            }
        }
        else if (demo)
        {
            Vector3 vel = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 8 * Time.deltaTime;
            r.MovePosition(transform.position + vel);
            bool e = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return);
            if (e && !on4Dhide)
            {
                is4Dhide = !is4Dhide;
                on4Dhide = true;
                StartCoroutine(hide());
            }
            if (is4Dhide)
            {
                heart.sprite = sprites[1];
            }
            if (!is4Dhide)
            {
                heart.sprite = sprites[0];
            }
        }
        
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody r = GetComponent<Rigidbody>(); if (ac)
        {
            if (other.tag == "spamton" && ac.fight && !r.isKinematic && !rig && !is4Dhide)
            {

                Settings.Player.Curent_Hero_healf -= 25;
                if (Settings.Player.Curent_Hero_healf <= 0) { SceneManager.LoadScene("GameOwer"); }
                StartCoroutine(RIG());
                if (!demo)
                {
                    tp.text = soul.tp.ToString();
                    if (soul.tp < 100 - 1) soul.tp += 1; else { soul.tp += 1; }
                    if (soul.tp < 100) tp.text = soul.tp.ToString(); else { tp.text = "owr"; }
                }

            }
        }
        else if (demo && !is4Dhide)
        {
            if (other.tag == "spamton" && !is4Dhide)
            {

                SceneManager.LoadScene("GameOwer");
            }
            if (other.tag == "Finish")
            {
                SceneManager.LoadScene("Hyper_spamton");
            }
        }
        resset.scene = SceneManager.GetActiveScene().buildIndex;
    }
   public IEnumerator RIG()
    {
        //  //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        // ScreenCapture.CaptureScreenshot("C:/Unauticna Multiverse/Screenshot" + Random.Range(0, int.MaxValue) + ".png", 1);
        //canvas_animator.Play("mog");

        rig = true;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.5f);
        rig = false;

        //  Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
  public  IEnumerator hide()
    {
        //  //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        // ScreenCapture.CaptureScreenshot("C:/Unauticna Multiverse/Screenshot" + Random.Range(0, int.MaxValue) + ".png", 1);
        //canvas_animator.Play("mog");

       

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);
      
        is4Dhide = false;
        yield return new WaitForSeconds(1.5f);
        on4Dhide = false;
        //  Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
}
