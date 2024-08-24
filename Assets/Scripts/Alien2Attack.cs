using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien2Attack : MonoBehaviour
{
    public float damage = 6;
    public Alien2Movement alien2Movement;
    public Animator anim;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TowerHealth>())
        {
            collision.gameObject.GetComponent<TowerHealth>().health -= damage;

        }
        if (collision.gameObject.GetComponent<AllyHealth>())
        {
            collision.gameObject.GetComponent<AllyHealth>().health -= damage;

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        alien2Movement.enabled = false;
        anim.SetBool("isAttacking", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        alien2Movement.enabled = true;
        anim.SetBool("isAttacking", false);
    }
}
