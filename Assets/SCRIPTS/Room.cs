using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;
    public Slime[] slimes;

    //virtual to override
    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && !col.isTrigger)
        {
            //activate enemies and slimes
            for(int i = 0; i< enemies.Length; i++)
            {
                ChangeAct(enemies[i], true);
            }
            for(int i=0; i< slimes.Length; i++)
            {
                ChangeAct(slimes[i], true);
            }
        }
    }
    public virtual void OnTriggerExit2D(Collider2D col)
    {
           
            if (col.CompareTag("Player") && !col.isTrigger)
            {
            //Deactivate enemies and slimes
                for (int i = 0; i < enemies.Length; i++)
                {
                    ChangeAct(enemies[i], false);
                }
                for (int i = 0; i < slimes.Length; i++)
                {
                    ChangeAct(slimes[i], false);
                }
            }
    }
    public void ChangeAct(Component c, bool Act)
    {
        c.gameObject.SetActive(Act);
    }
}
