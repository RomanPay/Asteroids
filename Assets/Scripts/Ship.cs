using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    
    // thrust and rotation support
    private Rigidbody2D _rigidbody2D;
    private Vector2 _thrustDirection = new Vector2(1, 0);
    private const float ThrustForce = 5f;
    private const float RotateDegreesPerSecond = 180f;
    
    
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // saved for efficiency
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Rotate the ship
    /// </summary>
    void Update()
    {
        // Check for rotation input
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {
            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
                rotationAmount *= -1;
            transform.Rotate(Vector3.forward, rotationAmount);
            
            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            _thrustDirection = new Vector2(Mathf.Cos(zRotation), Mathf.Sin(zRotation));
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject bullet = Instantiate(prefabBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().ApplyForce(_thrustDirection);
            
        }
    }
    
    /// <summary>
    /// Drive the ship
    /// </summary>
    void FixedUpdate()
    {
        // Thrust as appropriate
        if (Input.GetAxis("Thrust") > 0)
        {
            _rigidbody2D.AddForce(_thrustDirection * ThrustForce, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}
