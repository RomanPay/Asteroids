using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// An asteroid
/// </summary>
public class Asteroid : MonoBehaviour
{
    // Array sprites for asteroid
    [SerializeField] Sprite[] asteroidsSprites = new Sprite[3];
    
    void Start()
    {
        // Apply random sprite to asteroid
        GetComponent<SpriteRenderer>().sprite = asteroidsSprites[Random.Range(0, 3)];
    }

    public Asteroid()
    {
        
    }

    /// <summary>
    /// Initialize asteroid
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="location"></param>
    public void Initialize(Direction direction, Vector3 location)
    {
        transform.position = location;
        // Apply impulse force and set direction for asteroid 
        const float minImpulseAster = 1;
        const float maxImpulseAster = 5;
        float angle = 0f;

        switch (direction)
        {
            case Direction.Right :
                angle = Random.Range(15 * Mathf.Deg2Rad, -15 * Mathf.Deg2Rad);
                break;
            case Direction.Up :
                angle = Random.Range(75 * Mathf.Deg2Rad, 105 * Mathf.Deg2Rad);
                break;
            case Direction.Left :
                angle = Random.Range(165 * Mathf.Deg2Rad, 195 * Mathf.Deg2Rad);
                break;
            case Direction.Down :
                angle = Random.Range(255 * Mathf.Deg2Rad, 285 * Mathf.Deg2Rad);
                break;
        }
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(minImpulseAster, maxImpulseAster);
        
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }
}
