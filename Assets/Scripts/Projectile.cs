using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float spd = 10f;
    [SerializeField] private int damage = 25; 
    public void Init(Vector2 direction)
    {
        rb.velocity = direction * spd;
        Destroy(gameObject, 10);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //conditionals to deal damage to the objects with the scripts listed below
        if (other.transform.GetComponent<EnemyOneHealth>())
        {
            other.transform.GetComponent<EnemyOneHealth>().TakeDamage(damage);
        }
        else if (other.transform.GetComponent<Alien2Health>())
        {
            other.transform.GetComponent<Alien2Health>().TakeDamage(damage);
        }
        else if (other.transform.GetComponent<Alien4Health>())
        {
            other.transform.GetComponent<Alien4Health>().TakeDamage(damage);
        }


        Destroy(gameObject);  
    }

}
