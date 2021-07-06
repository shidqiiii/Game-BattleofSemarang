using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public float moveSpeed, distanceToPlayer;
    public Transform leftPoint, rightPoint;

    private bool movingRight;

    public Rigidbody2D theRB;
    private Animator anim;
    public SpriteRenderer theSR;

    public float moveTime, waitTime; 
    private float moveCount, waitCount;

    public float timeBetweenShots;
    private float shotCounter;

    Transform enemy;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theSR = GetComponentInChildren<SpriteRenderer>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;

        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            CheckPlayer();
        }
        
    }

    public void Movement()
    {
        if(moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if (movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                transform.eulerAngles = Vector2.zero;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
                transform.eulerAngles = Vector2.up * 180;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

            if (moveCount <= 0)
            {
                waitCount = Random.Range(0, waitTime);
            }
            anim.SetBool("isMoving", true);
        }
        else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if(waitCount <= 0)
            {
                moveCount = Random.Range(0, waitTime);
            }

            anim.SetBool("isMoving", false);
        }
        
    }

    public void CheckPlayer()
    {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToPlayer)
        {
            Movement();
        }
        else
        {
            theRB.velocity = new Vector2(0f, theRB.velocity.y);
            anim.SetBool("isMoving", false);

            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;

                EnemyShoot.instance.ShootBullet();
            }

            if (PlayerController.instance.transform.position.x < transform.position.x)
            {
                transform.eulerAngles = Vector2.up * 180;
            }
            else
            {
                transform.eulerAngles = Vector2.zero;
            }

        }
    }
}
