using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLoot : MonoBehaviour
{
    public int heart;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {

        }
    }

    
}
