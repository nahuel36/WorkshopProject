using UnityEngine;

public class Enemy : MonoBehaviour
{

    public enum Direction
    { 
    left,
    right
    }

    private Direction actualDirection;
    [SerializeField]float LeftLimit = -5;
    [SerializeField]float RightLimit = 5;
    [SerializeField] int damage = 10;

    public delegate void DamageAction(float damage);// UNITY LEARN EVENTS
    public static event DamageAction OnDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualDirection = Direction.right;
        GetComponent<Animator>().Play("Move");
    }

    // Update is called once per frame
    void Update()
    {

        if(Direction.left == actualDirection)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 2);
            if(transform.position.x < LeftLimit)
            {
                actualDirection = Direction.right; 
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else if(Direction.right == actualDirection)
        {
            if (transform.position.x > RightLimit)
            {
                actualDirection = Direction.left;
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
            OnDamage?.Invoke(damage); // Invoke the event if there are any subscribers
        }
    }

}
