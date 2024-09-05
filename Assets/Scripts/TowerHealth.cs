// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// public class TowerHealth : MonoBehaviour
// {
//     public float health;
//     public float maxHealth = 500;
//     public Slider slider;
//     // Start is called before the first frame update
//     void Start()
//     {
//         health = maxHealth;
//         slider.maxValue = maxHealth;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         slider.value = health;
//         if (health <= 0)
//         {
//             Destroy(slider.gameObject);
//             Destroy(gameObject);
//         }
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 500;
    public Slider slider;
    public AudioClip damageSound;  // Reference to the damage sound
    private AudioSource audioSource;  // Reference to the AudioSource
    private float previousHealth;  // To track health changes

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        previousHealth = health;  // Set initial health

        // Get the AudioSource component attached to the tower (Dome City)
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;

        // Check if health has decreased
        if (health < previousHealth)
        {
            PlayDamageSound();  // Play sound when health decreases
            previousHealth = health;  // Update previous health to current
        }

        // If health is depleted, destroy the object and its slider
        if (health <= 0)
        {
            Destroy(slider.gameObject);
            Destroy(gameObject);
        }
    }

    void PlayDamageSound()
    {
        if (damageSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);  // Play damage sound
        }
    }
}
