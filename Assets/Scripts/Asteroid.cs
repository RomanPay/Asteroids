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
    
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // Set random sprite to asteroid
        GetComponent<SpriteRenderer>().sprite = asteroidsSprites[Random.Range(0, 3)];
    }

    public Asteroid()
    {
        
    }

    /// <summary>
    /// Starts the asteroid moving in the given direction
    /// </summary>
    /// <param name="direction">direction for the asteroid to move</param>
    /// <param name="location">position for the asteroid</param>
    public void Initialize(Direction direction, Vector3 location)
    {
        // set asteroid position
        transform.position = location;
        
        // Set direction for asteroid 
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
        
        // get asteroid moving
        StartMoving(angle);
    }

    /// <summary>
    /// Starts the asteroid moving at the given angle
    /// </summary>
    /// <param name="angle">angle</param>
    public void StartMoving(float angle)
    {
        // Apply impulse force 
        const float minImpulseAster = 1;
        const float maxImpulseAster = 2;
        float magnitude = Random.Range(minImpulseAster, maxImpulseAster);
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Shrink asteroid to half size and clone twice
    /// </summary>
    private void SubAsteroid()
    {
        // Shrink
        Vector3 scale = gameObject.transform.localScale;
        scale.x /= 2;
        scale.y /= 2;
        GetComponent<CircleCollider2D>().radius /= 2;
        transform.localScale = scale;
        
        // Clone
        Vector3 position = transform.position;
        GameObject asteroidFirstHalf = Instantiate(gameObject, position, Quaternion.identity);
        asteroidFirstHalf.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
        GameObject asteroidSecondHalf =  Instantiate(gameObject, position, Quaternion.identity);
        asteroidSecondHalf.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
    }
    
    
    /// <summary>
    /// Destroy the asteroid on collision with a bullet
    /// </summary>
    /// <param name="other">collision info</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Destroy bullet
            Destroy(other.gameObject);
            AudioManager.Play(AudioClipName.AsteroidHit);
            
            // Destroy or split as appropriate
            if (gameObject.transform.localScale.x < 0.6)
                Destroy(gameObject);
            else
                SubAsteroid();

            // Destroy original asteroid
            Destroy(gameObject);
        }
    }
}
