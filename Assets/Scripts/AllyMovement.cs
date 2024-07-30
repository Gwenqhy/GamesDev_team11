using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public GameObject enemy;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = enemy.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, enemy.transform.position, speed * Time.deltaTime);
        
    }
}
