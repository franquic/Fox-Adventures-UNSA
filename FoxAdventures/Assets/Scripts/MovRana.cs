using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovRana : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    public Transform leftpoint , rightpoint;

    private bool movingRight;

    private Rigidbody2D theRB;
    private Animator anim;
    public SpriteRenderer theSR;

    public float moveTime, waitTime;
    private float moveCount, waitCount;


    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = transform.Find("Rana").GetComponent<Animator>();
        leftpoint.parent = null;
        rightpoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveCount> 0){
            moveCount -= Time.deltaTime ;
            if (movingRight){
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            theSR.flipX = true;

            if (transform.position.x > rightpoint.position.x){
                movingRight = false;
            }
        } else {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            theSR.flipX = false;

            if (transform.position.x < leftpoint.position.x){
                movingRight = true;
            }
        }
        if (moveCount <= 0){
            waitCount = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
        }
        anim.SetBool("IsMoving", true);
        } else if (waitCount > 0){
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if (waitCount <= 0){
                moveCount = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
            }
            anim.SetBool("IsMoving", false);

        }
        
    }
}
