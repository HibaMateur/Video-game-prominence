using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoss : MonoBehaviour
{

    public int damage = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Killable"))
        {
            col.GetComponent<Slime>().Kill();
        }
        if (col.CompareTag("Boss"))
        {

            BossHealth boss;
            boss = col.gameObject.GetComponent<BossHealth>();
            boss.HurtEnemy(damage);
        }

    }
}
