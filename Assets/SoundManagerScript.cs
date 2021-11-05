using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerDeathSound, CastSound, slashSound, enemyDeathSound, speak;
    static AudioSource audioSrc;
    // Start is called before the first frame update

    void Start()
    {
        playerDeathSound = Resources.Load<AudioClip>("playerDeathEffect");
        CastSound = Resources.Load<AudioClip>("cast");
        slashSound = Resources.Load<AudioClip>("swordSlash");
        enemyDeathSound = Resources.Load<AudioClip>("enemyDeathEffect");
        speak = Resources.Load<AudioClip>("speak");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerDeathEffect":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "cast":
                audioSrc.PlayOneShot(CastSound);
                break;
            case "swordSlash":
                audioSrc.PlayOneShot(slashSound);
                break;
            case "enemyDeathEffect":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "speak":
                audioSrc.PlayOneShot(speak);
                break;
        }
    }
}
