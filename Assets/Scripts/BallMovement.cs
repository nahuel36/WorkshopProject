using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BallMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;//tambien puede hacerse por busqueda con find o con getcomponent
    [SerializeField, ReadOnlyInInspector] bool _jump_charging;
    [SerializeField, ReadOnlyInInspector] int _onGround;
    [SerializeField] float _moveVelocity = 8;
    [SerializeField] float _jumpForce = 10;
    [SerializeField, ReadOnlyInInspector] Vector2 _move_dir;
    [SerializeField, ReadOnlyInInspector] Vector3 _platformDir;
    [SerializeField, ReadOnlyInInspector] float _time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _onGround = 0;
        _jump_charging = false;
    }

    private void Update()
    {
        

        if (_move_dir.x != 0 && _onGround > 0)
        { 
            _rb.AddTorque(30 * _moveVelocity * -_move_dir.x * Time.deltaTime);
            
            //IsSloped();
            //rb.linearVelocity = platformDir * move_dir.x * moveVelocity * Time.deltaTime * 300;
        }

        if (_onGround == 0)
        {
            RaycastHit2D hit_up = Physics2D.Raycast(transform.position - 0.5f * Vector3.down, Vector2.up);
            if (hit_up && hit_up.collider.CompareTag("Ground"))
            {
                hit_up.collider.isTrigger = true;

                TilemapCollider2D tilemapCollider =
                    hit_up.transform.GetComponent<TilemapCollider2D>();

                if (tilemapCollider != null)
                    tilemapCollider.isTrigger = true;
            }
            RaycastHit2D hit_down = Physics2D.Raycast(transform.position + 0.5f * Vector3.down, Vector2.down);
            if (hit_down && hit_down.collider.CompareTag("Ground"))
            {
                hit_down.collider.isTrigger = false;

                TilemapCollider2D tilemapCollider =
                    hit_down.transform.GetComponent<TilemapCollider2D>();

                if (tilemapCollider != null)
                    tilemapCollider.isTrigger = false;
            }
        }
            
        if(Keyboard.current.spaceKey.wasPressedThisFrame && _onGround > 0)
        {
            _jump_charging = true;
            _rb.bodyType = RigidbodyType2D.Kinematic;
            _time = Time.time;
            transform.DOPause();
            transform.DOScaleY(0.33f, 3);
            transform.DOLocalMoveY(transform.localPosition.y - 0.33f, 3);
        }

        if(Keyboard.current.spaceKey.wasReleasedThisFrame && _jump_charging)
        {
            _jump_charging = false;
            _rb.bodyType = RigidbodyType2D.Dynamic;
            transform.DOPause();
            transform.DOShakeScale(1).onComplete += () => transform.DOScale(1, 0.5f);//funcion lambda o funcion flecha
            _rb.AddForce(new Vector2(0, (_time - Time.time) * _jumpForce), ForceMode2D.Impulse);
            //transform.DOJump(new Vector3(transform.position.x, transform.position.y + (float)callbackCont.duration), 1, 1, 2);
        }

        if(Keyboard.current.rightArrowKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            if (Keyboard.current.rightArrowKey.isPressed)
                _move_dir.x = Keyboard.current.rightArrowKey.ReadValue();
            else if (Keyboard.current.leftArrowKey.isPressed)
                _move_dir.x = -Keyboard.current.leftArrowKey.ReadValue();
        }
        if(Keyboard.current.rightArrowKey.wasReleasedThisFrame || Keyboard.current.leftArrowKey.wasReleasedThisFrame)
        {
            _move_dir.x = 0;
            _rb.linearVelocityX = 0;
            _rb.angularVelocity = 0;
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _onGround++;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround++;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround--;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround--;
        }
    }
}
