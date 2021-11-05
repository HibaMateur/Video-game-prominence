﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyState
{
    idle,
    walk,
    attack,
    //they don't move until they back to walking state
    pause
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int currentHealth;
    public int halfhealth;
    public int maxHealth;
    public string enemyName;
    public int baseAttack;
    public GameObject deathEffect;
    public int speed;

    private bool flash;
    [SerializeField]
    private float flashLength = 0f;
    private float flashTimer = 0f;
    private SpriteRenderer enemyFlash;

    public Slider healthBar;

    public Signal roomSignal;
    public LootTable thisLoot;
    private Animator animator;
    private HitPlayer hitPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
        enemyFlash = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flash)
        {
            if (flashTimer > flashLength * .99f)
            {
                enemyFlash.color = new Color(enemyFlash.color.r, enemyFlash.color.g, enemyFlash.color.b, 0f);
            }
            else if (flashTimer > flashLength * .82f)
            {
                enemyFlash.color = new Color(enemyFlash.color.r, enemyFlash.color.g, enemyFlash.color.b, 1f);

            }
            else if (flashTimer > flashLength * .66f)
            {
                enemyFlash.color = new Color(enemyFlash.color.r, enemyFlash.color.g, enemyFlash.color.b, 0f);
            }
            else if (flashTimer > flashLength * .49f)
            {
                enemyFlash.color = new Color(enemyFlash.color.r, enemyFlash.color.g, enemyFlash.color.b, 1f);
            }
            else if (flashTimer > flashLength * .3f)
            {
                enemyFlash.color = new Color(enemyFlash.color.r, enemyFlash.color.g, enemyFlash.color.b, 0f);
            }
            else if (flashTimer > flashLength * .16f)
            {
                enemyFlash.color = new Color(enemyFlash.color.r, enemyFlash.color.g, enemyFlash.color.b, 1f);
            }
            else if (flashTimer > 0)
            {
                enemyFlash.color = new Color(enemyFlash.color.r, enemyFlash.color.g, enemyFlash.color.b, 1f);
            }
            else
            {
                enemyFlash.color = new Color(enemyFlash.color.r, enemyFlash.color.g, enemyFlash.color.b, 1f);
                flash = false;
            }
            flashTimer -= Time.deltaTime;
        }

        //healthBar.value = currentHealth;  
    }
    public void OnEnable()
    {
        currentHealth = maxHealth;
        currentState = EnemyState.idle;
    }
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        flash = true;
        flashTimer = flashLength;
       
        if (currentHealth <= 0)
        {
            DeathEffects();
            MakeLoot();
            if(roomSignal != null) { 
            roomSignal.Raise();
            }
            this.gameObject.SetActive(false);
            }
       
      
        

    }
    private void MakeLoot()
    {
        if(thisLoot != null)
        {
            Add current = thisLoot.LootAdd();
            if(current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    private void DeathEffects()
    {
        if(deathEffect != null)
        {//1f is the delay of the effect
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
}
