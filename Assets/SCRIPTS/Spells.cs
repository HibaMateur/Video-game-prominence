using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    [SerializeField]
    private float Speed=0;

    private Transform enemy;
    public GameObject player;
    //[SerializeField]
    private int dmg=4;
    //dmg not controlled.

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        //todo added a way to get the enemy based on the selected enemy
        player = GameObject.Find("Player");
        enemy = player.GetComponent<MovementsForPlayer>().myEnemy.transform;
        
      
        //enemy = GameObject.Find("Dinosaure").transform;
    }
    public void Initialize(Transform enemy, int dmg)
    {
        this.enemy = enemy;
        this.dmg = dmg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (enemy != null) { 
        Vector2 direction = enemy.position - transform.position;
        myRigidBody.velocity = direction.normalized * Speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Killable"))
        {
            col.GetComponent<Slime>().Kill();
        }
        if (col.CompareTag("Enemy"))
        {

            Enemy enemy;
             enemy = col.gameObject.GetComponent<Enemy>();
             enemy.HurtEnemy(dmg);
           
            GetComponent<Animator>().SetTrigger("Impact");
            myRigidBody.velocity = Vector2.zero;
        }
        if (col.CompareTag("Boss"))
        {
            BossHealth boss;
            boss = col.gameObject.GetComponent<BossHealth>();
            boss.HurtEnemy(dmg);
            GetComponent<Animator>().SetTrigger("Impact");
            myRigidBody.velocity = Vector2.zero;
        }

    }
   /* private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "HitBox")
        {
            Speed = 0; 
            col.GetComponentInParent<Enemy>().HurtEnemy(dmg);
            GetComponent<Animator>().SetTrigger("Impact");
            myRigidBody.velocity = Vector2.zero;
            enemy = null;
        }
    }*/
}
