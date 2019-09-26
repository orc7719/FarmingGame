using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraScript : MonoBehaviour
{
    [SerializeField] Transform player;
    float elasticity = 1.5f;
    int z;
    // Start is called before the first frame update
    void Start()
    {
        z = Mathf.RoundToInt(transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((player.position.x / elasticity), (player.position.y / elasticity), z);
    }
}
