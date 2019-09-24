using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MovementBobbleScript : MonoBehaviour
{
    AIPath ai;
    float bobbleRate = 1f;
    int angleToBobble = 10;
    bool haventRecentlyReset = true;
    void Start()
    {
        ai = GetComponentInParent<AIPath>();
    }
    void Update()
    {
        if ((ai.velocity.magnitude > 0) && !ai.reachedDestination)
        {
            if (!haventRecentlyReset)
            {
                haventRecentlyReset = true;
            }
            Vector3 currentEuler = transform.localEulerAngles;
            float z = currentEuler.z;
            if (z > angleToBobble)
            {
                if (z < (360 - angleToBobble))
                {
                    bobbleRate *= -1;
                }
            }
            z += bobbleRate;
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, z));
        }
        if (ai.reachedDestination && haventRecentlyReset)
        {
            ResetRotation();
            haventRecentlyReset = false;
        }
    }
    void ResetRotation()
    {
        Debug.Log("reset spam");
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
