using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager hm;
    private ManaManager mm;
    public Slider HealthBar;
    public Text hpText;
    public Slider ManaBar;
    public Text ManaText;
   
    // Start is called before the first frame update
    void Start()
    {
        hm = FindObjectOfType<HealthManager>();
        mm = FindObjectOfType<ManaManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.maxValue = hm.maxHealth;
        HealthBar.value = hm.currentHealth;
        hpText.text = "HP: " + hm.currentHealth + "/" + hm.maxHealth;


    }
   
}
