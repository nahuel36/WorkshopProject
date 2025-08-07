using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;//tambien puede hacerse por busqueda con find o con getcomponent
    bool jump_charging;
    int onGround;
    [SerializeField] float moveVelocity = 8;
    [SerializeField] float jumpForce = 10;
    Vector2 move_dir;
    Vector3 platformDir;
    float time;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        onGround = 0;
        jump_charging = false;
    }

    private void Update()
    {
        if (move_dir.x != 0 && onGround > 0)
        {
            isSloped();
            transform.Translate(platformDir * move_dir.x * Time.deltaTime * 10);//esto es para que gire al moverse, si no se quiere quitar
        }
        if (onGround == 0)
        {
            RaycastHit2D hit_up = Physics2D.Raycast(transform.position - 0.5f * Vector3.down, Vector2.up);
            if (hit_up && hit_up.collider.CompareTag("Ground"))
                hit_up.collider.isTrigger = true;

            RaycastHit2D hit_down = Physics2D.Raycast(transform.position + 0.5f * Vector3.down, Vector2.down);
            if (hit_down && hit_down.collider.CompareTag("Ground"))
            {
                hit_down.collider.isTrigger = false;
            }
        }
           
        

    }


    private void isSloped()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position + 0.5f * Vector3.down, Vector2.down);

        if (hit && hit.normal != Vector2.up)
        {
            platformDir = Vector3.ProjectOnPlane(platformDir, hit.transform.up).normalized;
        }
        else
        {
            platformDir = Vector2.right;
        }
    }
    public void Move(InputAction.CallbackContext callbackCont)
    {
        move_dir = callbackCont.ReadValue<Vector2>();

        if (move_dir != Vector2.zero)
        { 
            animator.Play("Move");
            if(move_dir.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (move_dir.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.Play("Idle");
        }
    }


    public void JumpCharge(InputAction.CallbackContext callbackCont)
    {
        if (callbackCont.started && onGround > 0)
        {
            jump_charging = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            time = Time.time;
            transform.DOPause();
            transform.DOScaleY(0.33f, 3);
            transform.DOLocalMoveY(transform.localPosition.y - 0.33f, 3);
        }
        if(callbackCont.canceled && jump_charging)
        {
            jump_charging = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            transform.DOPause();
            transform.DOShakeScale(1).onComplete += () => transform.DOScale(1, 0.5f);//funcion lambda o funcion flecha
            rb.AddForce(new Vector2(0, (time - Time.time) *jumpForce), ForceMode2D.Impulse);
            //transform.DOJump(new Vector3(transform.position.x, transform.position.y + (float)callbackCont.duration), 1, 1, 2);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround++;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround++;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround--;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround--;
        }
    }
}
