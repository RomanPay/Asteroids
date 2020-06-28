using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A bullet
/// </summary>
public class Bullet : MonoBehaviour
{
    // Death support
    private const float liveTimeBullet = 1.0f;
    private Timer _deathTimer;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // create and run death timer
        _deathTimer = gameObject.AddComponent<Timer>();
        _deathTimer.Duration = liveTimeBullet;
        _deathTimer.Run();
    }
    /// <summary>
    /// Apply force to bullet in the given direction
    /// </summary>
    /// <param name="direction">force direction</param>
    public void ApplyForce(Vector2 direction)
    {
        const float magnitude = 10.0f;
        GetComponent<Rigidbody2D>().AddForce(magnitude * direction, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Destroy bullet
    /// </summary>
    void Update()
    {
        // Destroy bullet when timer is done
        if (_deathTimer.Finished)
            Destroy(gameObject);
    }
}
