using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBoss : MonoBehaviour
{
    public int attackDamage = 5;
   

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    private HealthManager hm;
    public float waitToHurt = 2f;
    public bool isTouching;

    void Start()
    {
        hm = FindObjectOfType<HealthManager>();
    }

    public void Attack()
    {
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                hm.HurtPlayer(attackDamage);
                waitToHurt = 2f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            //col.gameObject.SetActive(false);
            col.gameObject.GetComponent<HealthManager>().HurtPlayer(attackDamage);
            //reloading = true;

        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            isTouching = true;
        }


    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }

}
