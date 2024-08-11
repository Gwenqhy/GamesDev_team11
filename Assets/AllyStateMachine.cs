using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyStateMachine : MonoBehaviour
{
    public Animator anim;
    public AllyDownMovement downMovement;
    public AllyLeftMovement leftMovement;
    public AllyRightMovement rightMovement;
    public AllyUpMovement upMovement;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("isShooting", true);
        downMovement.enabled = false;
        upMovement.enabled = false;
        leftMovement.enabled = false;
        rightMovement.enabled = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isShooting", false);
        downMovement.enabled = true;
        upMovement.enabled = true;
        leftMovement.enabled = true;
        rightMovement.enabled = true;
    }
}