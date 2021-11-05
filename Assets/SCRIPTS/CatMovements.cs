using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovements : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    //still private but can change it in the editor
    //[SerializeField]
    public float speed;
    //private float waitTime;
    //public float startWaitTime;
    //[SerializeField]
    public float maxRange;
    public float minRange;
    //public Transform[] moveSpots;
    private int randomSpot;
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
        animator.SetBool("Moving", false);

       /*transform.Translate(Vector2.right * speed * Time.deltaTime);
        transform.position =Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
    if(Vector2.Distance(transform.position, moveSpots[randomSpot].position)<0.02f){
        if(waitTime<=0){
            randomSpot = Random.Range(0, moveSpots.Length);
            waitTime= startWaitTime;
        }else{ waitTime-= Time.deltaTime;}
    }*/
        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position)> minRange ){
        FollowPlayer();

        }
        
    }

    public void FollowPlayer(){
        //animation
        animator.SetBool("Moving", true);
        //follow
        
        animator.SetFloat("MoveX", target.position.x - transform.position.x);
        animator.SetFloat("MoveY",  target.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
