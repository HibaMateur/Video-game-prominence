using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
    public GameObject contextC;
    public bool contextActive = false;
    
    public void ChangeContext()
    {
        contextActive = !contextActive;
        if (contextActive)
        {
            contextC.SetActive(true);
        }
        else
        {
            contextC.SetActive(false);
        }
    }
}
