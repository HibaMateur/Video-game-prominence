using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private MovementsForPlayer player;

    //todo: added these two public variables
    public GameObject selectedObject;
    //public LayerMask layerMask;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Todo removed ClickTarget() added my click mechanic
        //ClickTarget();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
        {
           
            if (hitData && Input.GetMouseButtonDown(0) && hitData.collider.tag =="Enemy")
            {

                selectedObject = hitData.transform.gameObject;
                Debug.Log("mouse click hit " + selectedObject.name);
                Debug.Log("Object transform = " + selectedObject.transform.position);
                player.myEnemy = selectedObject;
            }
     
        }


    }
    /*private void ClickTarget()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 512);
            if (hit.collider != null)
            {
             if (hit.collider.tag == "Enemy") { 
              Debug.Log("hit");
              player.myEnemy = hit.transform;
                }
            }
            else
            {//detarget target
                player.myEnemy = null;
                Debug.Log("no hit");
            }
       }
   }*/
}
