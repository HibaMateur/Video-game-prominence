using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public string sceneToLoad;
    private bool flash;
    [SerializeField]
    private float flashLength=0f;
    private float flashTimer = 0f;
    private SpriteRenderer playerFlash;
    // Start is called before the first frame update
    void Start()
    {
        playerFlash = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flash)
        {
            if (flashTimer>flashLength * .99f)
            {
                playerFlash.color = new Color(playerFlash.color.r, playerFlash.color.g, playerFlash.color.b, 0f);
            }else if(flashTimer>flashLength * .82f)
            {
                playerFlash.color = new Color(playerFlash.color.r, playerFlash.color.g, playerFlash.color.b, 1f);

            }
            else if (flashTimer > flashLength * .66f)
            {
                playerFlash.color = new Color(playerFlash.color.r, playerFlash.color.g, playerFlash.color.b, 0f);
            }
            else if (flashTimer > flashLength * .49f)
            {
                playerFlash.color = new Color(playerFlash.color.r, playerFlash.color.g, playerFlash.color.b, 1f);
            }
            else if (flashTimer > flashLength * .3f)
            {
                playerFlash.color = new Color(playerFlash.color.r, playerFlash.color.g, playerFlash.color.b, 0f);
            }
            else if (flashTimer > flashLength * .16f)
            {
                playerFlash.color = new Color(playerFlash.color.r, playerFlash.color.g, playerFlash.color.b, 1f);
            }
            else if (flashTimer > 0)
            {
                playerFlash.color = new Color(playerFlash.color.r, playerFlash.color.g, playerFlash.color.b, 1f);
            }
            else
            {
                playerFlash.color = new Color(playerFlash.color.r,playerFlash.color.g,playerFlash.color.b, 1f);
                flash = false;
            }
            flashTimer -= Time.deltaTime;
        }
    }
    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        flash = true;
        flashTimer = flashLength;
        if (currentHealth <= 0)
        {
            SoundManagerScript.PlaySound("enemyDeathEffect");
            gameObject.SetActive(false);
            
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        }
     

    }

}
