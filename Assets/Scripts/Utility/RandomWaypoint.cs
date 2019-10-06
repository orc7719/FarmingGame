using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWaypoint : MonoBehaviour
{
    float timeUntilNextWaypoint = 0;
    private void Update()
    {
        timeUntilNextWaypoint -= Time.deltaTime;
        if (timeUntilNextWaypoint < 0)
        {
            timeUntilNextWaypoint = 6f;
            transform.position = new Vector3(Random.Range(-3.5f, +2.8f), Random.Range(-1.95f, +1.95f), 0);
        }
    }
}
