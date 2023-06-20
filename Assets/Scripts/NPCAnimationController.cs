using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAnimationController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void SetSitting(bool value)
    {
        // Debug.Log("Set Sit: " + value);
        animator.SetBool("Sit", value);
    }
}
