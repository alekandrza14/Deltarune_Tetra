using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene_menager : MonoBehaviour
{
    [SerializeField] Animator anim;

    int z;

    void InputKey()
    {

        bool e = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return);

        if (e)
        {
            z++;
        }
        if (z >= 2)
        {
            anim.Play("cutscene_end");
            Destroy(this);
            z = 0;
        }

    }
    void Update()
    {
        InputKey();
    }
}
