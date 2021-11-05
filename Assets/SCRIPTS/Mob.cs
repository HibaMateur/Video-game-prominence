using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for health etc and we have monobehavior in enemy so it will inherit either ways
public class Dinosaure : MonoBehaviour
{
    private Animator animator;
    public Transform target;
    public Transform homePos;
    //still private but can change it in the editor
    //[SerializeField]
    public float speed;
    //private float waitTime;
    //public float startWaitTime;
    //[SerializeField]
    public float maxRange;
    public float minRange;
    //public Transform[] moveSpots;
    //private int randomSpot;

    // Start is called before the first frame update
    void Start()
    {
        //randomSpot = Random.Range(0, moveSpots.Length);
        animator = GetComponent<Animator>();
        target = FindObjectOfType<MovementsForPlayer>().transform;

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) > minRange)
        {
            FollowPlayer();

        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
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
    public void GoHome()
    {
        animator.SetFloat("MoveX", homePos.position.x - transform.position.x);
        animator.SetFloat("MoveY", homePos.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            animator.SetBool("Walk", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Weapon")
        {   
            Vector2 difference = transform.position - col.transform.position ;
            transform.position = new Vector2(transform.position.x + difference.x , transform.position.y + difference.y );

        }
    }
}

