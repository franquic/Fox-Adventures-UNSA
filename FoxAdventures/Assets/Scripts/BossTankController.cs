using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour
{
    public enum bossStates {shooting, hurt, moving, ended }
    public bossStates currentStates;

    public Transform theBoss;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;

    public Transform leftPoint, rightPoint;
    private bool moveRigth;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;

    public GameObject hitBox;

    [Header("Health")]
    public int health = 5;
    public GameObject explosion;
    private bool isDefeated;
    public float shotspeedUp; 

    
    // Start is called before the first frame update
    void Start()
    {
        currentStates = bossStates.shooting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentStates)
        {
            case bossStates.shooting:
                shotCounter -= Time.deltaTime;

                if (shotCounter<=0)
                {
                    shotCounter = timeBetweenShots/timeBetweenShots;
                    var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    newBullet.transform.localScale = theBoss.localScale;
                }

                break;
            case bossStates.hurt:
                if (hurtCounter>0)
                {
                    hurtCounter -= Time.deltaTime;
                    if (hurtCounter <=0)
                    {
                        currentStates = bossStates.moving;


                        if (isDefeated)
                        {
                            theBoss.gameObject.SetActive(false);
                            Instantiate(explosion, theBoss.position, theBoss.rotation);

                            currentStates = bossStates.ended;
                        }
                    }
                }

                break;
            case bossStates.moving:
                
                if( moveRigth)
                {
                    theBoss.position += new Vector3(moveSpeed * Time.deltaTime,0f,0f);

                    if(theBoss.position.x > rightPoint.position.x) 
                    {
                        theBoss.localScale = new Vector3(1f, 1f, 1f);
                        moveRigth= false;
                        EndMovement();
                    }
                }
                else
                {
                    theBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theBoss.position.x < leftPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(-1f, 1f, 1f);
                        moveRigth = true;
                        EndMovement();
                    }
                }

                break;

        }
    }
    public void TakeHit()
    {
        currentStates = bossStates.hurt;
        hurtCounter = hurtTime;

        anim.SetTrigger("Hit");


        health--;
        if(health <= 0)
        {
            isDefeated = true;
        }
        else
        {
            timeBetweenShots /= shotspeedUp;
        }
    }
    private void EndMovement()
    {
        currentStates = bossStates.shooting;
        shotCounter = timeBetweenShots;
        anim.SetTrigger("StopMoving");
        hitBox.SetActive(true);
    }
}
