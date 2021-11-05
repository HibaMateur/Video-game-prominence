using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//data for loot
//custom class
[System.Serializable]
public class Loot
{
    public Add thisLoot;
    public int lootChance;
}
[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] things;
    public Add LootAdd()
    {
        int prob = 0;
        int currentProb = Random.Range(0, 100);
        for (int i = 0; i<things.Length; i++)
        {
            prob += things[i].lootChance;
            if(currentProb <= prob)
            {
                return things[i].thisLoot;
            }
        }
        return null;
    }
}
