using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{

    public enum Direction
    { 
    left,
    right
    }

    private Direction _actualDirection;
    [SerializeField]float _leftLimit = -5;
    [SerializeField]float _rightLimit = 5;
    [SerializeField] int _damage = 10;

    public static event Action<float> onDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _actualDirection = Direction.right;
        GetComponent<Animator>().Play("Move");
    }

    // Update is called once per frame
    void Update()
    {

        if(Direction.left == _actualDirection)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 2);
            if(transform.position.x < _leftLimit)
            {
                _actualDirection = Direction.right; 
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else if(Direction.right == _actualDirection)
        {
            if (transform.position.x > _rightLimit)
            {
                _actualDirection = Direction.left;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            transform.Translate(Vector2.right * Time.deltaTime * 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            onDamage?.Invoke(_damage); // Invoke the event if there are any subscribers
        }
    }

}
