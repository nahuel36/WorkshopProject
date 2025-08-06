using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] float points;
    public delegate void CollectAction(float points);// UNITY LEARN EVENTS
    public static event CollectAction OnCollected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the tag "Collectible"
        if (collision.CompareTag("Player"))
        {
            OnCollected?.Invoke(points); // Invoke the event if there are any subscribers
            Destroy(gameObject);
        }
    }

    public void SetearValor1(int valor)
    { 
    
    }

    public void SetearValor2(bool valor)
    {

    }

    public void LlamarFuncionConValores(int valor1, bool valor2) 
    { 
        
    }
}
