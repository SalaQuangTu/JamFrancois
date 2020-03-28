using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheySeeMeRolling : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnUpdateMovement(MovementInfo info)
    {
        if (anim)
        {
            if (info.movementSpeed > 0.01f)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
    }
}
