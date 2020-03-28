using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Run : MonoBehaviour
{

    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        Run();
    }

    public void Run()
    {
        anim = GetComponent<Animator>();
        if (anim)
        {
            anim.SetBool("Run", true);
        }
    }

    public void StopRun()
    {
        if (anim)
        {
            anim.SetBool("Run", false);
        }
    }

    
}
