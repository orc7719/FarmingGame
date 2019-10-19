using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraScript : MonoBehaviour
{
    [SerializeField] Transform player = null;
    [SerializeField] float elasticity = 1.5f;
    [SerializeField] float lerpRate = 0.01f;
    int z;
    void Start()
    {
        z = Mathf.RoundToInt(transform.position.z);
    }
    void Update()
    {
        Vector3 currentPos = transform.position;
        Vector3 deltaPos = TargetPosition() - currentPos;
        deltaPos *= lerpRate;
        deltaPos = deltaPos + currentPos;
        transform.position = deltaPos;
    }
    Vector3 TargetPosition()
    {
        return new Vector3((player.position.x / elasticity), (player.position.y / elasticity), z);
    }
}
