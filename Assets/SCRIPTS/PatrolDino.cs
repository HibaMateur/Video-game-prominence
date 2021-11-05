using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolDino : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpot;
    private int randomSpot;
    public Transform target;
    public float maxRange;
    public float minRange;
    private Animator animator;
    /*public float minX;
    public float maxX;
    public float minY;
    public float maxY;*/

        //Doesnt work need to relook into it
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpot.Length);
        //moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        animator = GetComponent<Animator>();
        target = FindObjectOfType<MovementsForPlayer>().transform;
    }
    void update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) > minRange)
        {
            FollowPlayer();

        }else { 
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot[randomSpot].position) < 0.2f)
        {
                animator.SetBool("Walk", true);
                if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpot.Length);
                //moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }else
            {
                    animator.SetBool("Walk", true);
                    waitTime -= Time.deltaTime;
            }
        }
        }

    }
    public void FollowPlayer()
    {
        //animation
        animator.SetBool("Walk", true);
        //follow

        animator.SetFloat("MoveX", target.position.x - transform.position.x);
        animator.SetFloat("MoveY", target.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Weapon")
        {
            Vector2 difference = transform.position - col.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);

        }
    }
}
