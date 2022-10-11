using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycaster : MonoBehaviour {
    GameObject TheGameController;
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
            Debug.Log(string.Format("Did hit {0} at {1} ", hit.distance, hit.point));
            
            TheGameController.transform.position = new Vector3
            (
                hit.point.x,
                hit.point.y + TheGameController.transform.localScale.y,
                hit.point.z);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction*1000, Color.red);
            Debug.Log("Did not Hit");
        }
    }
    void Start () {

         TheGameController = GameObject.FindGameObjectsWithTag("Capsule")[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
