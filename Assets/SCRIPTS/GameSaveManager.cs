using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    //static is smthing that won't be changed when loaded
    public static  GameSaveManager gameSave;
    public List<ScriptableObject> objects = new List<ScriptableObject>();
    
   

    private void Awake()
    {
        if (gameSave == null)
        {
            gameSave = this;
           
        } else
        {//destroy the script not the game object to not have one more than a time
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
