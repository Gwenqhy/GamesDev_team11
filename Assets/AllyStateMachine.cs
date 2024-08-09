using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyStateMachine : MonoBehaviour
{
    bool isShooting = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
   
        anim = gameObject.GetComponent<Animator>();
 
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
            

        }
    }
        

    

}