using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    public Transform leftpoint, rightpoint;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentPoint = pointA.transform;


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        print("Current Point: " + currentPoint.position);
        print("Distance " + Vector2.Distance(transform.position, currentPoint.position));

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.8f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
            Flip();


        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.8f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
            Flip();

        }


    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }




}




