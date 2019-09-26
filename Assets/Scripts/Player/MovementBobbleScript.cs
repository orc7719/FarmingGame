using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MovementBobbleScript : MonoBehaviour
{
    AIPath ai;
    float bobbleRate = 100f;
    int angleToBobble = 10;
    bool haventRecentlyReset = false;
    AudioSource footsteps;
    void Start()
    {
        ai = GetComponentInParent<AIPath>();
        footsteps = GetComponent<AudioSource>();
    }
    void Update()
    {
        if ((ai.velocity.magnitude > 0) && !ai.reachedEndOfPath)
        {
            if (!haventRecentlyReset)
            {
                footsteps.Play();
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
            z += bobbleRate * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, z));
        }
        if (ai.reachedEndOfPath && haventRecentlyReset)
        {
            ResetRotation();
        }
    }
    void ResetRotation()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        haventRecentlyReset = false;
        footsteps.Stop();
    }
}
