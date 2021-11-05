using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Add
{
    HealthManager playerHealth;
    public int HealthBonus = 10;

   
    void Awake()
    {
        playerHealth = FindObjectOfType<HealthManager>();
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (playerHealth.currentHealth < playerHealth.maxHealth)
        {
            
            playerHealth.currentHealth = playerHealth.currentHealth + HealthBonus;
            Destroy(gameObject);
        }
        //powerupSignal.Raise();
        
    }
}
