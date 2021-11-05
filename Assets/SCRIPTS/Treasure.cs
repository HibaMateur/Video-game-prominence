using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : Interactable
{
    public Object contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Bool savedOpen;

    [Header ("Signals and Dialog")]
    public Signal raiseObject;
    public GameObject dialogWindow;
    public Text dialogText;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = savedOpen.RuntimeValue;
        if (isOpen)
        {
            animator.SetBool("Opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && showDialog)
        {
            if (!isOpen)
            {
                //open the chest
                OpenChest();
            }
            else
            {
                //chest is already open
                ChestIsOpen();
            }
        }
    }
    public void OpenChest()
    {
        //Dialog pops up 
        dialogWindow.SetActive(true);
        //dialog text = contents text
        dialogText.text = contents.objectDescrip;
        //add item to inventory
        playerInventory.AddObject(contents);
        playerInventory.currentObject = contents;
        //Raise the signal to the player for animation
        raiseObject.Raise();
        //raise the context
        context.Raise();
        //set the chest to opened
        isOpen = true;
        animator.SetBool("Opened", true);
        savedOpen.RuntimeValue = isOpen;
    }
    public void ChestIsOpen()
    {
        
         //Disable Dialog
         dialogWindow.SetActive(false);
         //raise the signal to the player to stop the animation
         raiseObject.Raise();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !col.isTrigger && !isOpen)
        {
            context.Raise();
            showDialog = true;

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !col.isTrigger && !isOpen)
        {
            context.Raise();
            showDialog = false;

        }
    }
}
