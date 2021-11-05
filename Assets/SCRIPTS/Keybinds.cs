using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Keybinds : MonoBehaviour
{
    [SerializeField]
    private Button[] actionButtons;

    private KeyCode action1, action2, action3;

    [SerializeField]
    private CanvasGroup keybindmenu;

    private GameObject[] KeyBindButtons;
    private void Awake()
    {
        KeyBindButtons = GameObject.FindGameObjectsWithTag("Keybind");
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //Keybinds
        action1 = KeyCode.Alpha1;
        action2 = KeyCode.Alpha2;
        action3 = KeyCode.Alpha3;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(action1))
        {
            
            actionButtonOnClick(0);
        }
        if (Input.GetKeyDown(action2))
        {
            actionButtonOnClick(1);
        }
        if (Input.GetKeyDown(action3))
        {
            actionButtonOnClick(2);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }
    private void actionButtonOnClick(int btnIndex)
    {
        actionButtons[btnIndex].onClick.Invoke();
    }
    public void OpenMenu()
    {
        keybindmenu.alpha = keybindmenu.alpha > 0 ? 0 : 1;
        keybindmenu.blocksRaycasts = keybindmenu.blocksRaycasts == true ? false : true;
        //pause game
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
    }
    public void UpdateKeyText(string key, KeyCode keyBind)
    {
        Text tmp = Array.Find(KeyBindButtons, x => x.name == key).GetComponentInChildren<Text>();
        tmp.text = keyBind.ToString();
    }
}
