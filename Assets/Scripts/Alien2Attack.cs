using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien2Attack : MonoBehaviour
{
    public float damage = 10;
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
}
