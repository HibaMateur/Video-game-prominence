using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    walk,
    attack
}
public class Boss : MonoBehaviour
{
    public BossState currentState;
    private Animator animator;
    public Transform target;
    public float speed;
    public float maxRange;
    public float minRange;
    public float attackRange = 4f;
    Transform player;
    Rigidbody2D rb;



    void Start()
    {
        //randomSpot = Random.Range(0, moveSpots.Length);
        animator = GetComponent<Animator>();
        target = FindObjectOfType<MovementsForPlayer>().transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) > minRange)
        {
            FollowPlayer();

        }
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            StartCoroutine(AttackCo());
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
  

   public IEnumerator AttackCo()
    {
        currentState = BossState.attack;
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1f);
        currentState = BossState.walk;
        animator.SetBool("Attack", false);
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
