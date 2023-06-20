using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class NPCController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI patientText;
    [SerializeField] float rotationSpeed;
    [SerializeField] float startingPatient;
    [SerializeField] float patientTimer;

    GameObject selectedChair;
    NavMeshAgent agent;
    QueueManager queueManager;
    DestoryManager destoryManager;
    ListOfChairs listOfChair;
    Vector3 destination;
    PlayerScript playerScript;
    int positionInList;
    bool seated;
    bool delete;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        queueManager = FindObjectOfType<QueueManager>();
        destoryManager = FindObjectOfType<DestoryManager>();
        listOfChair = FindObjectOfType<ListOfChairs>();
        playerScript = FindObjectOfType<PlayerScript>();

        patientTimer = startingPatient;
        patientText.gameObject.SetActive(false);
    }

    void Start()
    {
        if (listOfChair.GetAvailableChairs() < 0)
        {
            Debug.Log("negative available chairs");
        }
        else if (queueManager.GetQueueLength() > 0 || listOfChair.GetAvailableChairs() == 0)
        {
            agent.destination = queueManager.GetQueuePosition();
            positionInList = queueManager.AddToQueue(gameObject);
        }
        else
        {
            foreach (GameObject chair in listOfChair.GetChairArray())
            {
                ChairStatus chairStatus = chair.GetComponent<ChairStatus>();

                if (!chairStatus.IsOccupied())
                {
                    SetChair(chair);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        patientText.text = Mathf.Ceil(patientTimer).ToString("0");

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            patientText.gameObject.SetActive(true);
            agent.updateRotation = false;
            patientTimer -= Time.deltaTime;

            if (selectedChair != null)
            {
                seated = true;
                transform.rotation = Quaternion.Slerp(transform.rotation, selectedChair.transform.rotation, rotationSpeed * Time.deltaTime);
            }
            else if (positionInList == 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 270, 0)), rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            seated = false;
            agent.updateRotation = true;
        }

        if (patientTimer <= 0 && !delete)
        {
            patientText.gameObject.SetActive(false);
            patientTimer = 0;
            delete = true;

            queueManager.RemoveFromList(gameObject);
            agent.destination = destoryManager.GetExitPosition();
            UpdateOrderStatus(false);

            if (selectedChair != null)
            {
                selectedChair.GetComponent<ChairStatus>().SetUnoccupied();
                selectedChair = null;
            }
        }
    }

    public void SetChair(GameObject chair)
    {
        positionInList = -1;
        ChairStatus chairStatus = chair.GetComponent<ChairStatus>();

        agent.destination = chair.transform.position;
        selectedChair = chair;
        chairStatus.SetOccupied();

        if (patientTimer / startingPatient < 0.5)
            patientTimer = startingPatient / 2;
    }

    public void MoveForwardInQueue(int i)
    {
        positionInList = i;
        Vector3 destination = agent.destination;
        destination.z -= 1;
        agent.destination = destination;

        patientTimer += 5;
    }

    public void UpdateOrderStatus(bool orderComplete)
    {
        if (orderComplete)
        {
            playerScript.CustomerServed();
        }
        else
        {
            playerScript.CustomerLeft();
        }
        // seated = false;
        agent.destination = destoryManager.GetExitPosition();
        selectedChair.GetComponent<ChairStatus>().SetUnoccupied();
        selectedChair = null;
    }

    public bool isSeated()
    {
        return seated;
    }
}
