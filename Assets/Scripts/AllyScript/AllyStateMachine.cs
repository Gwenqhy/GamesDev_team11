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
        if (anim != null)
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            Debug.LogError("Animator component is not assigned in the Inspector!");
        }

        DisableMovements();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (anim != null)
        {
            anim.SetBool("isShooting", false);
        }

        EnableMovements();
    }

    private void DisableMovements()
    {
        if (downMovement != null) downMovement.enabled = false;
        if (upMovement != null) upMovement.enabled = false;
        if (leftMovement != null) leftMovement.enabled = false;
        if (rightMovement != null) rightMovement.enabled = false;
    }

    private void EnableMovements()
    {
        if (downMovement != null) downMovement.enabled = true;
        if (upMovement != null) upMovement.enabled = true;
        if (leftMovement != null) leftMovement.enabled = true;
        if (rightMovement != null) rightMovement.enabled = true;
    }
}