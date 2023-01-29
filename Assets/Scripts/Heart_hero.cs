using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Heart_hero : MonoBehaviour
{

    [SerializeField] acts ac;
    public Animator canvas_animator;
    bool rig;
    [SerializeField] Text tp;
    void Update()
    {
        Rigidbody r = GetComponent<Rigidbody>();
        if (ac.fight && !r.isKinematic)
        {
            Vector3 vel = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 8 * Time.deltaTime;
            r.MovePosition(transform.position + vel);
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody r = GetComponent<Rigidbody>();
        if (other.tag == "spamton" && ac.fight && !r.isKinematic && !rig)
        {

            Settings.Player.Curent_Hero_healf -= 25;
            if (Settings.Player.Curent_Hero_healf <= 0) { SceneManager.LoadScene("GameOwer"); }
            StartCoroutine(RIG());
            tp.text = soul.tp.ToString();
            if (soul.tp < 100 - 1) soul.tp += 1; else { soul.tp += 1; }
            if (soul.tp < 100) tp.text = soul.tp.ToString(); else { tp.text = "owr"; }

        }
    }
    IEnumerator RIG()
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
}
