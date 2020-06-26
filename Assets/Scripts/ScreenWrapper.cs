using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wrap game objects
/// </summary>
public class ScreenWrapper : MonoBehaviour
{
    // screen wrapping support
    float colliderRadius;

    void Start()
    {
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    /// <summary>
    /// Make the ship wrap
    /// </summary>
    private void OnBecameInvisible()
    {
        Vector2 position = transform.position;
        
        //check all sides screen
        if (position.x - colliderRadius > ScreenUtils.ScreenRight || 
            position.x + colliderRadius < ScreenUtils.ScreenLeft)
        {
            position.x *= -1;
        }

        if (position.y - colliderRadius > ScreenUtils.ScreenTop ||
            position.y + colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // move ship
        transform.position = position;
    }
}
