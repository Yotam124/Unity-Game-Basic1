using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State {idle, running, jumping, falling};
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;

    private KeyCode moveRight = KeyCode.RightArrow;
    private KeyCode moveLeft = KeyCode.LeftArrow;
    private KeyCode jump = KeyCode.UpArrow;

    [Tooltip("Movement speed")] [SerializeField] private float speed = 6f;
    [Tooltip("Jump height")] [SerializeField] private float jumpHeight = 6f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveLeft))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetKey(moveRight))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            
        }
        if (Input.GetKey(jump) && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            state = State.jumping;
        }
        VelocityState();
        anim.SetInteger("state", (int)state);
    }

    private void VelocityState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < 0.1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            //Moving
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
}
