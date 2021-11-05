using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogScene : MonoBehaviour
{


    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int i;
    public int j;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject nextButton;
    public Animator textAnim;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == sentences[i])
        {
            continueButton.SetActive(true);
            nextButton.SetActive(true);
        }
        int j=0;
   
    }

    protected IEnumerator Type()
    {
        foreach (char letter in sentences[i].ToCharArray())
        {

            textDisplay.text += letter;
            
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        
        
        if (i < sentences.Length - 1)
        {
            i++;
           
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else 
        {
            
            textDisplay.text = "";
           

        }
        
    }
 

    public void LoadScene(string name)
    {
        
        SceneManager.LoadSceneAsync(name);
    }
}

