using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    [Header("Scene to load and its variables")]
    public string sceneToLoad;
    public Vector2 PlayerPosition;
    public VectorValue playerStorage;
    //Need to change camera min and max because of rooms
    public Vector2 cameraNewMin;
    public Vector2 cameraNewMax;
    public VectorValue cameraMin;
    public VectorValue cameraMax;
    [Header ("Effects when transition, variables")]
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !col.isTrigger)
        {
            playerStorage.initialValue = PlayerPosition;
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(sceneToLoad);

        }
    }
    public IEnumerator FadeCo()
    {
        if(fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        ResetCameraPosition();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
    public void ResetCameraPosition()
    {
        //initialvalue because vector value
        cameraMax.initialValue = cameraNewMax;
        cameraMin.initialValue = cameraNewMin;
    }
}
