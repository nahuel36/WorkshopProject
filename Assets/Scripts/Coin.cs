using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField]int _points = 10;
    public static event Action<int> onCollected;
    [SerializeField, ReadOnlyInInspector] private bool _isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the tag "Collectible"
        if (collision.CompareTag("Player") && !_isCollected)
        {
            _isCollected = true;
            onCollected?.Invoke(_points); // Invoke the event if there are any subscribers
            Destroy(gameObject);
        }
    }

}
