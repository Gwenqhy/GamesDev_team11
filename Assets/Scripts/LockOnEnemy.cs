using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnEnemy : MonoBehaviour
{

    public Transform currentLockedOnEnemy=null;    // The currently locked-on enemy
    public float RangeOfDetection = 10f; // Radius to detect enemies
    public LayerMask enemyLayer;     // Layer to detect enemies
    public float lockOnSpeed = 2f;   // Speed at which the player locks onto the enemy
    Vector2 posLastFrame;
    Vector2 posThisFrame;
    Direction movementDirection;
    // Update is called once per frame
    void Update()
    {
        posLastFrame = posThisFrame;

        posThisFrame = transform.position;

        movementDirection = CheckMoveDirection();
        if (movementDirection == Direction.Left)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movementDirection == Direction.Right)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        DetectClosestEnemy();

        if (currentLockedOnEnemy)
        {
            // Lock onto the enemy
            LockOntoEnemy();

        }
    }
    enum Direction { Right, Left, Still };
    Direction CheckMoveDirection()
    {
        if (posThisFrame.x > posLastFrame.x)
            return Direction.Right;
        else if (posThisFrame.x < posLastFrame.x)
            return Direction.Left;
        else
            return Direction.Still;
    }
    void DetectClosestEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, RangeOfDetection, enemyLayer);
        if (enemiesInRange.Length!=0)
        {
            float shortestDistance = Mathf.Infinity;
            Transform closestDetectedEnemy = null;

            foreach (var enemyCollider in enemiesInRange)
            {
                float distance = Vector2.Distance(transform.position, enemyCollider.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestDetectedEnemy = enemyCollider.transform;
                }
            }

            currentLockedOnEnemy = closestDetectedEnemy;
        }

    }
    void LockOntoEnemy()
    {
        if (currentLockedOnEnemy == null) { return; }
        else { 

        Vector2 direction = (currentLockedOnEnemy.position - transform.position).normalized;
        float step = lockOnSpeed * Time.deltaTime;
;       
        transform.position = Vector2.MoveTowards(transform.position, currentLockedOnEnemy.position, step);
        }
    }

}
