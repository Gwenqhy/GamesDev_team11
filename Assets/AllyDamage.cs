using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDamage : MonoBehaviour
{
    public float damage = 6;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>())
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= damage;
            

        }
        if (collision.gameObject.GetComponent<Alien2Health>())
        {
            collision.gameObject.GetComponent<Alien2Health>().health -= damage;
        }
        if (collision.gameObject.GetComponent<Alien4Health>())
        {
            collision.gameObject.GetComponent<Alien4Health>().health -= damage;
        }
    }
}
