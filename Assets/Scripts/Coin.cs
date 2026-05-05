using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField]int points = 10;
    public static event Action<int> OnCollected;
    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the tag "Collectible"
        if (collision.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            OnCollected?.Invoke(points); // Invoke the event if there are any subscribers
            Destroy(gameObject);
        }
    }

}
