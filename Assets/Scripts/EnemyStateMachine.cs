using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public Animator anim;
    public EnemyMovement enemyMovement;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("isShooting",true);
        enemyMovement.enabled = false;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isShooting", false);
        enemyMovement.enabled = true;
    }
}