using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float spd;
    [SerializeField] private int damage = 25; 
    public void Init(Vector2 direction)
    {
        rb.velocity = direction * spd;
        Destroy(gameObject, 10);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.GetComponent<EnemyScriptForTurret>().TakeDamage(damage);
 
        Destroy(gameObject);  
    }

}
