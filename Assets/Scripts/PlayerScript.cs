using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 3f;
    Controls controls;
    Vector2 move = Vector2.zero;
    Rigidbody2D rb;
    bool jumping = true;

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

        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 6) {
            jumping = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = controls.KBM.Movement.ReadValue<Vector2>();
    }
}
