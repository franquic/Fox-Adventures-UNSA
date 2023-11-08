using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    [Header("Movement")]
    public float moveSpeed;

    [Header("Jumping")]
    private bool canDoubleJump;
    public float jumpForce;

    [Header("Components")]
    public Rigidbody2D rb;

    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer sr;

    [Header("Ground Check")]
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask groundLayer;

    public float knockBackLenght, knockBackForce;
    private float knockBackCounter;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (knockBackCounter <= 0)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, groundLayer);

            if (isGrounded)
            {
                canDoubleJump = true;
            }
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    AudioManager.instance.PlaySFX(10);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        canDoubleJump = false;
                        AudioManager.instance.PlaySFX(10);
                    }
                }
            }

            if (rb.velocity.x < 0)
            {
                sr.flipX = true;
            }
            else if (rb.velocity.x > 0)
            {
                sr.flipX = false;
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if (!sr.flipX)
            {
                rb.velocity = new Vector2(-knockBackForce, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(knockBackForce, rb.velocity.y);
            }
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);



    }

    public void Knockback()
    {
        knockBackCounter = knockBackLenght;
        rb.velocity = new Vector2(0f, knockBackForce);
    }
}
