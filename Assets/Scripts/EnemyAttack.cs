using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 6;
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Deal damage to object with TowerHealth script
        if(collision.gameObject.GetComponent<TowerHealth>())
        {
            collision.gameObject.GetComponent<TowerHealth>().health -= damage;
            
        }
        // Deal damage to object with AllyHealth script
        if (collision.gameObject.GetComponent<AllyHealth>())
        {
            collision.gameObject.GetComponent<AllyHealth>().health -= damage;
            
        }
    }
}
