using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnEnemy : MonoBehaviour
{
    public GameObject leftFacingPrefab;    // Prefab for facing left
    public GameObject rightFacingPrefab;
    public Transform currentLockedOnEnemy;    // The currently locked-on enemy
    public float detectionRadius = 10f; // Radius to detect enemies
    public LayerMask enemyLayer;     // Layer to detect enemies
    public float lockOnSpeed = 2f;   // Speed at which the player locks onto the enemy
   

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();

        if (currentLockedOnEnemy != null)
        {
            // Lock onto the enemy
            LockOntoEnemy();

        }
    }

    void FindClosestEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (var enemyCollider in enemiesInRange)
        {
            float distance = Vector2.Distance(transform.position, enemyCollider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemyCollider.transform;
            }
        }

        currentLockedOnEnemy = closestEnemy;
    }

    void LockOntoEnemy()
    {
        if (currentLockedOnEnemy == null) return;

        Vector2 direction = (currentLockedOnEnemy.position - transform.position).normalized;
        float step = lockOnSpeed * Time.deltaTime;
;

         transform.position = Vector2.MoveTowards(transform.position, currentLockedOnEnemy.position, step);
    }
}
