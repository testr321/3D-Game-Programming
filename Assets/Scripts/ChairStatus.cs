using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairStatus : MonoBehaviour
{
    [SerializeField] bool occupiedChair;
    [SerializeField] bool test;
    
    QueueManager queueManager;
    ListOfChairs listOfChair;

    void Awake()
    {
        queueManager = FindObjectOfType<QueueManager>();
        listOfChair = FindObjectOfType<ListOfChairs>();
    }

    void Update()
    {
        if (LevelChanger.isChangingScene)
            return;
            
        if (test)
        {
            SetUnoccupied();
            test = false;
        }
    }

    public void SetOccupied()
    {
        occupiedChair = true;
        listOfChair.DecreaseAvailableChairs();
    }

    public void SetUnoccupied()
    {
        occupiedChair = false;
        queueManager.ChairAvailable(gameObject);
        listOfChair.IncreaseAvailableChairs();
    }

    public bool IsOccupied()
    {
        return occupiedChair;
    }
}
