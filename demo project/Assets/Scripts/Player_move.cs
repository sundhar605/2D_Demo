using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float drix;
    public Rigidbody2D rb;
    [SerializeField] float speed = 400f;
    [SerializeField] float jumpForce = 5f;

    bool isGrounded ;
    SpriteRenderer SpriteRenderer;
    BoxCollider2D boxCollider;
    [SerializeField] LayerMask Groundmask;
    Animator animator;
    private enum Movementstate { idel, run, jump,fall}
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = rb.GetComponent<SpriteRenderer>();
        boxCollider = rb.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        drix = Input.GetAxisRaw("Horizontal");
       
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() )
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce , 0f);
        }
        Handel_anime();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(drix * speed * Time.deltaTime, rb.linearVelocity.y, 0f);
    }
    bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, Groundmask);
    }
    void Handel_anime()
    {
        Movementstate state;

        if (drix > 0)
        {
            SpriteRenderer.flipX = false;
            state = Movementstate.run;
        }
        else if (drix < 0)
        {
            SpriteRenderer.flipX = true;
            state = Movementstate.run;
        }
        else
        {
            state = Movementstate.idel;
        }
        if(rb.linearVelocity.y > 0.1f)
        {
            state = Movementstate.jump;
        }
        else if(rb.linearVelocity.y < -0.1f)
        {
            state = Movementstate.fall;
        }

        animator.SetInteger("state",(int) state);
    }

}
