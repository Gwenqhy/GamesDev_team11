using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyStateMachine : MonoBehaviour
{
    public Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (anim != null)
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            Debug.LogError("Animator component is not assigned in the Inspector!");
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (anim != null)
        {
            anim.SetBool("isShooting", false);
        }

    }

}