using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDamageTrigger : MonoBehaviour
{
    public float damage = 6;
    private void OnTriggerStay2D(Collider2D collision)
    {
        //deals damage to gameObject with EnemyOneHealth script
        if (collision.gameObject.GetComponent<EnemyOneHealth>())
        {
            collision.gameObject.GetComponent<EnemyOneHealth>().health -= damage;
        }
        //deals damage to gameObject with Alien2Health script
        if (collision.gameObject.GetComponent<Alien2Health>())
        {
            collision.gameObject.GetComponent<Alien2Health>().health -= damage;
        }
        //deals damage to gameObject with Alien4Health script
        if (collision.gameObject.GetComponent<Alien4Health>())
        {
            collision.gameObject.GetComponent<Alien4Health>().health -= damage;
        }
    }
}
