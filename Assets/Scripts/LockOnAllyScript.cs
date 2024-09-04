using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnAllyScript : MonoBehaviour
{

    public Transform currentLockedOnAlly = null;    // The currently locked-on ally
    public float RangeOfDetection = 10f; // Radius to detect allies
    public LayerMask AllyLayer;     // Layer to detect allies
    public float lockOnSpeed = 2f;   // Speed at which the player locks onto the ally
    Vector2 posLastFrame;
    Vector2 posThisFrame;
    Direction movementDirection;
    public SpriteRenderer spriteRenderer;
    // Update is called once per frame
    void Update()
    {
        posLastFrame = posThisFrame;

        posThisFrame = transform.position;

        movementDirection = CheckMoveDirection();
        if (movementDirection == Direction.Left)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementDirection == Direction.Right)
        {
            spriteRenderer.flipX = false;
        }
        DetectClosestAlly();

        if (currentLockedOnAlly)
        {
            // Lock onto the ally
            LockOntoAlly();

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
    void DetectClosestAlly()
    {
        Collider2D[] alliesInRange = Physics2D.OverlapCircleAll(transform.position, RangeOfDetection, AllyLayer);
        if (alliesInRange.Length != 0)
        {
            float shortestDistance = Mathf.Infinity;
            Transform closestDetectedally = null;

            foreach (var allyCollider in alliesInRange)
            {
                float distance = Vector2.Distance(transform.position, allyCollider.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestDetectedally = allyCollider.transform;
                }
            }

            currentLockedOnAlly = closestDetectedally;
        }

    }
    void LockOntoAlly()
    {
        if (currentLockedOnAlly == null) { return; }
        else
        {

            Vector2 direction = (currentLockedOnAlly.position - transform.position).normalized;
            float step = lockOnSpeed * Time.deltaTime;
            ;
            transform.position = Vector2.MoveTowards(transform.position, currentLockedOnAlly.position, step);
        }
    }

}
