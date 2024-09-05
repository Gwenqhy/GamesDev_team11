// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TowerDamage : MonoBehaviour
// {
//     public float damage = 6;
//     private void OnCollisionStay2D(Collision2D collision)
//     {
//         if (collision.gameObject.GetComponent<EnemyHealth>())
//         {
//             collision.gameObject.GetComponent<EnemyHealth>().health -= damage;

//         }
        
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamage : MonoBehaviour
{
    public float damage = 6;
    public AudioClip damageSound; // Reference to the sound clip
    private AudioSource audioSource; // Reference to the AudioSource

    private void Start()
    {
        // Get the AudioSource component attached to the object
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        Debug.Log("Collision detected and damage applied.");

        
        if (enemyHealth)
        {
            enemyHealth.health -= damage;

            // Play the damage sound effect
            if (damageSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(damageSound);
            }
        }
    }
}

