using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && showDialog)
        {
            
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
             
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player") && !col.isTrigger)
        {//player out of range
          
            context.Raise();
            showDialog = false;
            dialogBox.SetActive(false);
        }
    }

}
