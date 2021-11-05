using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitPlayer : MonoBehaviour
{
    private HealthManager hm;
    public float waitToHurt =2f;
    public bool isTouching;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        hm = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  if (reloading)
          {
              waitToLoad -= Time.deltaTime;
              if(waitToLoad <= 0)
              {
                  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
              }
          }
      */
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                hm.HurtPlayer(damage);
                waitToHurt = 2f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
            //col.gameObject.SetActive(false);
            col.gameObject.GetComponent<HealthManager>().HurtPlayer(damage);
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
