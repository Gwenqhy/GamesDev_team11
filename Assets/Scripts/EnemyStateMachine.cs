using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    bool isShooting = false;
    private Animator anim;
    private EnemyMovement movementScript;
    // Start is called before the first frame update
    void Start()
    {
   
        anim = gameObject.GetComponent<Animator>();
        movementScript = gameObject.GetComponent<EnemyMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isShooting = true;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isShooting = false;
    }
    void Update()
    {
        Debug.Log(isShooting);
        if (isShooting)
        {
            anim.Play("Shooting");

        }
    }
        

    

}