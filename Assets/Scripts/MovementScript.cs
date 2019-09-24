using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MovementScript : MonoBehaviour
{
    AIPath ai;
    void Start()
    {
        ai = GetComponent<AIPath>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ai.destination = Get2DMousePosition();
        }
    }
    Vector2 Get2DMousePosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(pos.x, pos.y);
    }
}
