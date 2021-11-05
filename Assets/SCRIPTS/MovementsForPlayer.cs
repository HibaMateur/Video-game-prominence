using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    interact,
    attack,
    spell
}

public class MovementsForPlayer : MonoBehaviour
{
    #region Private Variables
    private Stats health;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 pos;
    #endregion

    [Header("Player: Stats")]
    public PlayerState currentState;
    [SerializeField] 
    private float moveSpeed;

    [Header("Player: SpellCasting")]
    [SerializeField] 
    private Transform[] exitPoints;
    private int exitIndex = 2;
    private SpellBook spellBook;
    private ManaManager mana;
    // private BlockSight[] blocks; //if not in sight you can'tattack
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer lootedObjectSprite;
    [Header("Player: Targetting")]
    public GameObject myEnemy;
    public GameObject projectile;
  

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spellBook = GetComponent<SpellBook>();
        mana = GetComponent<ManaManager>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentState = PlayerState.walk;
        transform.position = startingPosition.initialValue;

    }

    private void Update()
    {
        //is the player in an interaction
        if(currentState== PlayerState.interact)
        {
            return;
        }
        pos = Vector3.zero;
        if (currentState == PlayerState.walk && currentState != PlayerState.spell /* or whatever state you want */)
        {
            pos.x = Input.GetAxisRaw("Horizontal");
            pos.y = Input.GetAxisRaw("Vertical");
        }
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            SoundManagerScript.PlaySound("swordSlash");
            StartCoroutine(AttackCoroutine());
        }
        /*else if(Input.GetButtonDown("Second Attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(ProjectileCoroutine());
        }*/
        else if (currentState == PlayerState.walk)
        {
            AnimationMovement();
        }
    }
    private IEnumerator AttackCoroutine()
    {
        animator.SetBool("Attack", true);
        currentState = PlayerState.attack;
        //a delay one frame
        yield return null;
        animator.SetBool("Attack", false);
        yield return new WaitForSeconds(.25f);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }
    /*private IEnumerator ProjectileCoroutine()
    {
        animator.SetBool("Spell", true);
        currentState = PlayerState.attack;
        //a delay one frame
        yield return null;
        MakeProjectile();
        animator.SetBool("Spell", false);
        yield return new WaitForSeconds(.25f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }
    private void MakeProjectile()
    {
        //create spell at position of player
        Vector2 temp = new Vector2(animator.GetFloat("MoveX"), animator.GetFloat("MoveY"));
        Projectile p= Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
        p.Setup(temp, ChooseProjectileDirection());
    }

    Vector3 ChooseProjectileDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("MoveY"), animator.GetFloat("MoveX"));
        return new Vector3(0, 0, temp);
    }
    */
    public void RaiseObject()
    {
        if(playerInventory.currentObject !=null )
        { 
        if(currentState != PlayerState.interact)
        {
            animator.SetBool("found object", true);
            currentState = PlayerState.interact;
            lootedObjectSprite.sprite = playerInventory.currentObject.objectSprite;
        }
        else
        {
            animator.SetBool("found object", false);
            currentState = PlayerState.walk;
            lootedObjectSprite.sprite = null;
            playerInventory.currentObject = null;
                
        }
        }
    }
    void AnimationMovement()
    {
        if (pos != Vector3.zero)
        {
            FixedUpdate();
            animator.SetFloat("MoveX", pos.x);
            animator.SetFloat("MoveY", pos.y);
            //this part where if i remove my finger the animation stays for a while
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
    //This Update is for manipulation of physics stuff usually like rigidbody stuff.
    private void FixedUpdate()
    {
        pos.Normalize();
        rb.MovePosition(transform.position + pos * moveSpeed * Time.deltaTime);
    }

    private IEnumerator Spell(int spellIndex)
    {
        //able to change target while casting need to look into it.
        if (currentState != PlayerState.spell)
        {
            SpellScript newSpell = spellBook.CastSpell(spellIndex);
            animator.SetBool("Spell", true);
            //a delay one frame     
            yield return new WaitForSeconds(newSpell.CastTime);
            Debug.Log("Done Casting");
            animator.SetBool("Spell", false);
            yield return new WaitForSeconds(.25f);  
            //inlineofsight needs to be add
            if (myEnemy != null && currentState != PlayerState.interact) {

             Instantiate(newSpell.SpellPrefab, exitPoints[exitIndex].position, Quaternion.identity);
                //s.Initialize(myEnemy, newSpell.Damage);
                currentState = PlayerState.walk;
            }
        }
      
    }
  
    public void CastSpell(int spellIndex)
    {
       
        if (myEnemy != null)
        {
            SoundManagerScript.PlaySound("cast");
            Debug.Log("Spell cast");
            StartCoroutine(Spell(spellIndex));
        }
      
    }
}
/*    public void CastSpell(int spellIndex)
    {
        if (myEnemy != null && IfInSight() )
        {

            Debug.Log("Spell cast");
            StartCoroutine(Spell(spellIndex));
        }
        else
        {
            Debug.Log("not Casting as no enemy or not in sight");
        }



    }
*/