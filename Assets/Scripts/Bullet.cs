using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A bullet
/// </summary>
public class Bullet : MonoBehaviour
{
    private const float liveTimeBullet = 2.0f;
    private Timer _deathTimer;

    void Start()
    {
        _deathTimer = gameObject.AddComponent<Timer>();
        _deathTimer.Duration = liveTimeBullet;
        _deathTimer.Run();
    }
    /// <summary>
    /// Apply force to bullet
    /// </summary>
    /// <param name="direction">moving direction</param>
    public void ApplyForce(Vector2 direction)
    {
        const float magnitude = 5.0f;
        GetComponent<Rigidbody2D>().AddForce(magnitude * direction, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (_deathTimer.Finished)
            Destroy(gameObject);
    }
}
