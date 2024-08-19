using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien4Movement : MonoBehaviour
{
    public GameObject player;
    public float speed = (float)0.5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
