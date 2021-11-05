using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCfinal : Sign
{
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && showDialog)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
            StartCoroutine(DelayedSceneLoadCo(sceneToLoad, 2f));
        }
       
    }

    private IEnumerator DelayedSceneLoadCo(string sceneToLoad, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
