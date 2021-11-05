using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Sign
{
    private Vector3 directionV;
    private Transform transform;
    public float speed;
    private Rigidbody2D rb;
    private Animator animator;
    
    //never walk more than
    public Collider2D boundaries;
    private bool isMoving;
    //whn it reaches 0 it changes direction

    private float moveTimeSeconds;
    private float waitTime;
    private float waitTimeSeconds;
    public float minMove;
    public float maxMove;
    public float minWaitTime;
    public float maxWaitTime;

    void Start()
    {
        moveTimeSeconds = Random.Range(minMove, maxMove);
        waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && showDialog)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
        if (isMoving)
        {
            moveTimeSeconds -= Time.deltaTime;
            if(moveTimeSeconds <= 0)
            {
                moveTimeSeconds = Random.Range(minMove, maxMove);
                isMoving = false;
            }
            if (!showDialog)
            {
                Move();
            }
        }
        else
        {
            waitTimeSeconds -= Time.deltaTime;
            if(waitTimeSeconds <= 0)
            {
                ChooseAnotherDirection();
                isMoving = true;
                waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
            }
        }
        
    }
    private void ChooseAnotherDirection()
    {
        Vector3 temp = directionV;
        ChangeDirection();
        //loop
        int i = 0;
        while (temp == directionV && i < 100)
        {
            i++;
            ChangeDirection();
        }

    }

    private void Move()
    {
        Vector3 temp = transform.position + directionV * speed * Time.deltaTime;
        if (boundaries.bounds.Contains(temp)) { 
        rb.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                //walk right
                directionV = Vector3.right;
                break;
            case 1:
                //walk back
                directionV = Vector3.up;
                break;
            case 2:
                //walk left
                directionV = Vector3.left;
                break;
            case 3:
                //walk front
                directionV = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }
    void UpdateAnimation()
    {
        animator.SetFloat("MoveX", directionV.x);
        animator.SetFloat("MoveY", directionV.y);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        ChooseAnotherDirection();
    }
}
