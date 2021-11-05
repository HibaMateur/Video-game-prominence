using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public Rigidbody2D myRigidbody;
    public int damage;

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }
    public void OntriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) {
         
            Destroy(this.gameObject);
        }
    }
}
