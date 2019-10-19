using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MovementBobbleScript : MonoBehaviour
{
    AIPath ai = null;
    AudioSource footsteps = null;
    [SerializeField] Animator playerAnim = null;
    [SerializeField] Animator bobbleAnim = null;

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
