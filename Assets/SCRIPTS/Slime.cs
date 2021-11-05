using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private Animator Anim;
    private Heart heart;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void Kill()
    {
        Anim.SetBool("Kill", true);
        StartCoroutine(breakCoroutine());
    }
    IEnumerator breakCoroutine()
    {
        yield return new WaitForSeconds(.9f);
        this.gameObject.SetActive(false);

    }
}
