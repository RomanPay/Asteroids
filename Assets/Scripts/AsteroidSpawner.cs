using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabAsteroid;
    
    /// <summary>
    /// Instantiation four asteroids and apply direction from all sides screen
    /// </summary>
    void Start()
    {
        foreach (Direction dir in Enum.GetValues(typeof(Direction)))
        {
            GameObject asteroid = Instantiate(prefabAsteroid);
            float radCollider = prefabAsteroid.GetComponent<CircleCollider2D>().radius * 2;
            switch (dir)
            {
                case Direction.Left :
                    asteroid.GetComponent<Asteroid>()
                        .Initialize(dir, new Vector3(ScreenUtils.ScreenRight + radCollider, 0, 0));
                    break;
                case Direction.Right :
                    asteroid.GetComponent<Asteroid>()
                        .Initialize(dir, new Vector3(ScreenUtils.ScreenLeft - radCollider, 0, 0));
                    break;
                case Direction.Up :
                    asteroid.GetComponent<Asteroid>()
                        .Initialize(dir, new Vector3(0, ScreenUtils.ScreenBottom - radCollider, 0 ));
                    break;
               case Direction.Down :
                    asteroid.GetComponent<Asteroid>()
                        .Initialize(dir, new Vector3(0, ScreenUtils.ScreenTop + radCollider, 0));
                    break;
            }
            
        }
    }
}
