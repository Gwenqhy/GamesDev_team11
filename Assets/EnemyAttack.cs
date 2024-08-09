using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public double damage = 6.25;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<TowerHealth>())
        {
            collision.gameObject.GetComponent<TowerHealth>().health -= damage;
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<AllyHealth>())
        {
            collision.gameObject.GetComponent<AllyHealth>().health -= damage;
            
        }
    }
}
