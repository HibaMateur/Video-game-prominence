using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button,
    boss
}

public class Door : Interactable
{
    [Header("Door Variables")]
    public DoorType thisDoor;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D boxCollider;

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (showDialog && thisDoor == DoorType.key)
            {
                //if player has key use open method
                if(playerInventory.numberOfKeys > 0)
                {
                    //remove one key from player inventory
                    playerInventory.numberOfKeys--;
                    OpenDoor();
                }
            }
        }
    }

   public void OpenDoor()
    {
        //Turn off the door's sprite renderer set open to true and remove the door's box collider
        doorSprite.enabled = false;
        open = true;
        boxCollider.enabled = false;
    }
    public void CloseDoor()
    {

    }
}
