using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDamageTrigger : MonoBehaviour
{
    public float damage = 6;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyOneHealth>())
        {
            collision.gameObject.GetComponent<EnemyOneHealth>().health -= damage;
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
