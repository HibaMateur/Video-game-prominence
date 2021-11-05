using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    //camera needs to know what to follow
	public Transform follow;
	public float Glissante;
	public Vector2 minPosition;
	public Vector2 maxPosition;
    //reset camera
    public VectorValue camMin;
    public VectorValue camMax;
    // Start is called before the first frame update
    void Start()
    {
        maxPosition = camMax.initialValue;
        minPosition = camMin.initialValue;
        transform.position = new Vector3(follow.position.x, follow.position.y, transform.position.z);
    }

    // Update is called once per frame
  	 void Update()
    {	if(transform.position != follow.position){
    		Vector3 followPosition = new Vector3(follow.position.x, follow.position.y,transform.position.z);
    		followPosition.x = Mathf.Clamp(followPosition.x, minPosition.x, maxPosition.x);
      		followPosition.y = Mathf.Clamp(followPosition.y, minPosition.y, maxPosition.y);
    		transform.position = Vector3.Lerp(transform.position, followPosition, Glissante);
    	 
    	
    }
        
    }

}