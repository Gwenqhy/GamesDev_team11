﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDownMovement : MonoBehaviour
{
    public Rigidbody2D robotRb;
    public int speed;
    private void FixedUpdate()
    {
        robotRb.velocity = Vector2.down * speed;
    }
}
