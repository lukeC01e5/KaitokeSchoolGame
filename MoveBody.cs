using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBody: MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirx = 0f;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private enum MovementState {idle, running, jumping }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
        UpDateAnimationState();
    }
        
    private void UpDateAnimationState()
        {
        MovementState state;

            if (dirx > 0f)
            {
                state = MovementState.running;
                sprite.flipX = false;
        }
            else if (dirx < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                state = MovementState.idle;
            }

            if(rb.velocity.y >.1f)
            {
            state = MovementState.jumping;
            }
            else if(rb.velocity.y > .1f)
                { state = MovementState.idle; }


            anim.SetInteger("state", (int)state);

        }
        private bool IsGrounded()
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        }

}


