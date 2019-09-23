using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("left click detected");
            this.transform.position = Get2DMousePosition();
        }
    }
    Vector2 Get2DMousePosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(pos.x, pos.y);
    }
}
