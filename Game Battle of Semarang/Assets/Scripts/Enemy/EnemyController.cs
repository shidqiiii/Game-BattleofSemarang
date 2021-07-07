using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    public enum EnemyStates { shooting, hurt, moving, ended };
    public EnemyStates currentStates;

    public Transform theEnemy;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool moveRight;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform shotPoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")]
    public float hurtTime;
    private float hurtCoutner;
    public GameObject hitBox;

    [Header("Health")]
    public int health = 3;
    public GameObject deathEffect, collectible;
    private bool isDefeated;
    public float shotSpeedUp;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStates = EnemyStates.shooting;
    }

    // Update is called once per frame
    void Update()
    {
        EnenmySwitchState();
    }

    public void EnenmySwitchState()
    {
        switch (currentStates)
        {
            case EnemyStates.shooting:
                shotCounter -= Time.deltaTime;

                if(shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;
                    var newBullet = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                    newBullet.transform.localScale = theEnemy.localScale;
                }

                break;

            case EnemyStates.hurt:
                if(hurtCoutner > 0)
                {
                    hurtCoutner -= Time.deltaTime;

                    if(hurtCoutner <=0)
                    {
                        currentStates = EnemyStates.moving;

                        if (isDefeated)
                        {
                            theEnemy.gameObject.SetActive(false);
                            Instantiate(deathEffect, theEnemy.position, theEnemy.rotation);
                            Instantiate(collectible, theEnemy.position, theEnemy.rotation);

                            currentStates = EnemyStates.ended;
                        }
                    }
                }

                break;

            case EnemyStates.moving:
                if (moveRight)
                {
                    theEnemy.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if(theEnemy.position.x > rightPoint.position.x)
                    {
                        theEnemy.localScale = new Vector3(.5f, .5f, 1f);
                        moveRight = false;

                        EndMovement();
                    }
                }
                else
                {
                    theEnemy.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theEnemy.position.x < leftPoint.position.x)
                    {
                        theEnemy.localScale = new Vector3(-.5f, .5f, 1f);
                        moveRight = true;

                        EndMovement();
                    }
                }

                break;
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeHit();
        }
#endif

    }

    public void TakeHit()
    {
        currentStates = EnemyStates.hurt;
        hurtCoutner = hurtTime;
        anim.SetTrigger("Hit");

        health--;
        if(health <= 0)
        {
            isDefeated = true;
        }
        else
        {
            timeBetweenShots /= shotSpeedUp;
        }
    }

    private void EndMovement()
    {
        currentStates = EnemyStates.shooting;

        shotCounter = timeBetweenShots;
        anim.SetTrigger("StopMoving");

        hitBox.SetActive(true);
    }
}
