using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelToPosition : MonoBehaviour
{
    public Vector3 ShootRay(int x, int y)
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
            Debug.Log(string.Format("Did hit {0} at {1} ", hit.distance, hit.point));
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
            Debug.Log("Did not Hit");
        }

        return hit.point;
    }

    // Start is called before the first frame update
    void Start()
    {
        //small test
        ShootRay(200, 210);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
