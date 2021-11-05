using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signal context;
    public bool showDialog;
    
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
        if(col.CompareTag("Player") && !col.isTrigger)
        {
            context.Raise();
            showDialog = true;

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player") && !col.isTrigger)
        {
            context.Raise();
            showDialog = false;
            
        }
    }
}
