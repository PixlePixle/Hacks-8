using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float maxSpeed = 10f;
    [SerializeField]
    float jumpForce = 3f;
    Controls controls;
    Vector2 move = Vector2.zero;
    Rigidbody2D rb;

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
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        Debug.Log("Wheeeeeeeeee");
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

    // Update is called once per frame
    void Update()
    {
        move = controls.KBM.Movement.ReadValue<Vector2>();
    }
}
