using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool Active;
    public Bool storedValue;
    public Sprite activeSprite;
    private SpriteRenderer s;
    public Door door;

    // Start is called before the first frame update
    void Start()
    {
        
        s = GetComponent<SpriteRenderer>();
        Active = storedValue.RuntimeValue;
        if (Active)
        {
            Activate();
        }
    }

    public void Activate()
    {
        Active = true;
        storedValue.RuntimeValue = Active;
        door.OpenDoor();
        s.sprite = activeSprite;

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //if player
        if (col.CompareTag("Player")){
            Activate();
        }
    }
}
