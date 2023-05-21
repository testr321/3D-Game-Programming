using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    Test cLocation;
    Vector3 destination;

    // Start is called before the first frame update
    void Awake()
    {
        cLocation = GetComponent<Test>();
    }

    void Start()
    {
        destination = cLocation.chairLoc[0];
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = destination;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
