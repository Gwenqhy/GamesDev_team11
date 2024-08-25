using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamage : MonoBehaviour
{
    public float damage = 6;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>())
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= damage;

        }
        
    }
}
