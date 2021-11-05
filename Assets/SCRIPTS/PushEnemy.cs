using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//add force to 2dRigidbody
public class PushEnemy : MonoBehaviour
{
    public float force;
    public float time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * force;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCoroutine(enemy));
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(time);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }
}
    
