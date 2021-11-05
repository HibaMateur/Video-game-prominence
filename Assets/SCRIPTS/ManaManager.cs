using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public float currentMana;
    public float maxMana;
    public float IncreasePerSecond=1f;
    public Text ManaText;
    public Slider ManaBar;
    private ManaManager mm;

    void Start()
    {
   
        mm = FindObjectOfType<ManaManager>();


    }

    void Update()
    {
        currentMana += IncreasePerSecond * Time.deltaTime;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        if (currentMana < 0)
        {
            currentMana = 0;
        }
        ManaBar.maxValue = mm.maxMana;
        ManaBar.value = mm.currentMana;
        ManaText.text = "Mana: "+(int)currentMana+"/" +maxMana;
        
    }
  
 

    public void ReduceMana(int mana)
    {
        if(mana <= currentMana) { 
        currentMana -= mana;
        }
   

    }

}
