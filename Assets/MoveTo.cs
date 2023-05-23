using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public GameObject chair;
    Test cLocation;
    Vector3 destination;
    NavMeshAgent agent;

    public float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        //cLocation = GetComponent<Test>();
        destination.Set(5, 5, 5);
        agent = GetComponent<NavMeshAgent>();
        cLocation = chair.GetComponent<Test>();
    }

    void Start()
    {
        destination = cLocation.chairLoc[0];
        agent.destination = destination;
        agent.updateRotation = false;

        Debug.Log("destination: " + destination);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (agent.remainingDistance > agent.stoppingDistance)
            agent.transform.LookAt(cLocation.chairLoc[0]);
        else
            agent.transform.rotation = cLocation.chairRot[0];
        */
        
        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            Quaternion targetRotation = cLocation.chairRot[0]; //Quaternion.LookRotation(agent.velocity.normalized);
            agent.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }


        /*if (agent.remainingDistance > agent.stoppingDistance)
        {
            Vector3 direction = (destination - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }*/
    }
}
