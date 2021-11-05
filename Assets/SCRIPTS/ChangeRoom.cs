using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{	public Vector2 newCamMinPos;
	public Vector2 newCamMaxPos;
	public Vector3 PlayerNewPos;
	private CameraMov cam;
    // Start is called before the first frame update
    void Start()
    {	cam= Camera.main.GetComponent<CameraMov>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider){
    	//check the tag of collider if player in trigger zone
    	if(collider.tag=="Player"){
    		cam.minPosition = newCamMinPos;
    		cam.maxPosition = newCamMaxPos;
    		collider.transform.position +=PlayerNewPos;
    		
    	}
    }
}
