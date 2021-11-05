using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{   private Slider content;

    private float CurrentFill;
    public float MaxValue { get; set; }
    private float CurrentValue;
    [SerializeField]
    private Text statValue;
    [SerializeField]
    private Stats health;
    //because of this prop we can make sure our health doesnt go above health;
    public float MyCurrentValue 
    {   get {
            return CurrentValue; 
        }
        set { 
            if(MaxValue < value)
            {
                CurrentValue = MaxValue;
            }
            else if (0> value)
            {
                CurrentValue = 0;
            }
            else 
            {
                CurrentValue = value;
            }
            CurrentFill = CurrentValue / MaxValue;
            if(statValue != null)
            {
                statValue.text = CurrentValue + "/" + MaxValue;
            }
            
        }
    }

  
    // Start is called before the first frame update
    void Start()
    {//content to acces the fill amount 
        content = GetComponent<Slider>();
        //content.fillAmount = 0.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
