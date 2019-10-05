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
    [SerializeField] Animator playerAnim;
    [SerializeField] Animator bobbleAnim;

    void Start()
    {
        ai = GetComponentInParent<AIPath>();
        footsteps = GetComponent<AudioSource>();
    }
    void Update()
    {
        playerAnim.SetFloat("PlayerSpeed", ai.velocity.magnitude);
        bobbleAnim.SetFloat("PlayerSpeed", ai.velocity.magnitude);
    }
}
