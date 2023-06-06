using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public GameObject chair;
    public GameObject status;
    public GameObject[] chairArray;

    Test testScript;
    ChairStatus chairStatus;

    Vector3 destination;

    NavMeshAgent agent;

    public float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        //destination.Set(5, 5, 5);
        agent = GetComponent<NavMeshAgent>();
        testScript = chair.GetComponent<Test>();
    }

    void Start()
    {
        //destination = testScript.chairLoc[0];
        chairArray = testScript.chairArray;

        foreach (GameObject chair in testScript.chairArray)
        {
            chairStatus = chair.GetComponent<ChairStatus>();

            if(chairStatus.occupiedChair == false)
            {
                destination = chair.transform.position;
                chairStatus.UpdateOccupancy();
                Debug.Log(destination);
                break;
            }
        }

        agent.destination = destination;
        agent.updateRotation = false;

        Debug.Log("destination: " + destination);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (agent.remainingDistance > agent.stoppingDistance)
            agent.transform.LookAt(testScript.chairLoc[0]);
        else
            agent.transform.rotation = testScript.chairRot[0];
        */
        
        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            Quaternion targetRotation = testScript.chairRot[0]; //Quaternion.LookRotation(agent.velocity.normalized);
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
