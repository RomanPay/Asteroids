using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The HUD
/// </summary>
public class HUD : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private float _storeElapseSeconds = 0f;

    private bool _isGameRunning = true;
    
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        
    }

    public void StopGameTimer()
    {
        _isGameRunning = false;
    }

    void Update()
    {
        _storeElapseSeconds += Time.deltaTime;
        
        if (_isGameRunning)
        {
            string elapsedSecond = ((int) _storeElapseSeconds).ToString();
            scoreText.text = "Playing time: " + elapsedSecond;
        }
    }
}
