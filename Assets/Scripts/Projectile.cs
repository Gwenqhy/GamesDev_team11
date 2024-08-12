using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float spd;

    public void Init(Vector2 direction)
    {
        rb.velocity = direction * spd;
        Destroy(gameObject, 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.GetComponent<EnemyScriptForTurret>().Destroyed();

        Destroy(gameObject);
    }
}
