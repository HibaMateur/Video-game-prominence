using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Object currentObject;
    public List<Object> objects = new List<Object>();
    public int numberOfKeys;
    public int coins;

    public void AddObject(Object objectLooted)
    {
        //if key
        if (objectLooted.Key)
        {//increase number of keys
            numberOfKeys++;
        }
        else
        {
            if (!objects.Contains(objectLooted))
            {//if something else looted
                objects.Add(objectLooted);
            }
        }
    }
}
