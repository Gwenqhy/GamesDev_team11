using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyUpMovement : MonoBehaviour
{
    public Rigidbody2D robotRb;
    public int speed=1;
    private void FixedUpdate()
    {
        robotRb.velocity = Vector2.up * speed;
    }
}
