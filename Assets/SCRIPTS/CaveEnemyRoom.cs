using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveEnemyRoom : CaveRoom
{
    public Door[] doors;
    

    public void CheckEnemies()
    {
        for(int i = 0; i< enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy && i< enemies.Length -1) {

                return;
            }
        }
        OpenDoors();
    }
    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !col.isTrigger)
        {
            //activate enemies and slimes
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeAct(enemies[i], true);
            }
            for (int i = 0; i < slimes.Length; i++)
            {
                ChangeAct(slimes[i], true);
            }
        }
        CloseDoors();
    }
    public override void OnTriggerExit2D(Collider2D col)
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
 
    public void CloseDoors()
    {
        for(int i = 0; i<doors.Length; i++)
        {
            doors[i].CloseDoor();
        }
    }
    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].OpenDoor();
            
        }
    }
}
