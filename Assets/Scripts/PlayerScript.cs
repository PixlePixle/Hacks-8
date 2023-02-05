using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 3f;
    [SerializeField]
    Animator animator;
    Controls controls;
    Vector2 move = Vector2.zero;
    [SerializeField]
    float sideScrollSpeed = 0f;
    Rigidbody2D rb;
    bool jumping = true;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    Camera cam;

    private void Awake()
    { 
        controls = new Controls();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        controls.Enable();
        controls.KBM.Jump.performed += _ => jump();
    }


    private void jump()
    {
        if (!jumping) {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
        }
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void FixedUpdate()
    {
        /*if(Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddForce(new Vector2(move.x * speed, 0));
        }*/

        rb.velocity = new Vector2((move.x * speed) + sideScrollSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 6) {
            jumping = false;
        } else if (collision.gameObject.layer == 7)
        {
            doWin();
        }
    }

    public void doWin()
    {
        SceneManager.LoadScene("win");
    }

    // Update is called once per frame
    void Update()
    {
        move = controls.KBM.Movement.ReadValue<Vector2>();

        if (rb.velocity.x > 0)
            spriteRenderer.flipX = false;
        if (rb.velocity.x < 0)
            spriteRenderer.flipX = true;
        if(jumping)
        {
            animator.SetBool("IsJumping", true);
        } else
        {
            animator.SetBool("IsJumping", false);
        }

        if (Mathf.Abs(rb.velocity.x) > 0.2 && !jumping)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
