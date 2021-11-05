using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public int damage=2;
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
        
        if (col.CompareTag("Enemy"))
        {
            Enemy enemy;
            enemy = col.gameObject.GetComponent<Enemy>();
            enemy.HurtEnemy(damage);
        }

    }
}
