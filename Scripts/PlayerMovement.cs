using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    public bool isPlayer2;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling }


    [SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    

    // Update is called once per frame
    public void Update()
    {
        var leftButton = isPlayer2 ? KeyCode.LeftArrow : KeyCode.A;
        var rightButton = isPlayer2 ? KeyCode.RightArrow : KeyCode.D;
        var jumpButton = isPlayer2 ? KeyCode.UpArrow : KeyCode.Space;
        dirX = Input.GetKey(rightButton) ? 1.0f : 0.0f;
        dirX = Input.GetKey(leftButton)? -1.0f : dirX;
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
      if(Input.GetKeyDown(jumpButton) && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y <-.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
