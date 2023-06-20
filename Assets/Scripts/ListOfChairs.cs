using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfChairs : MonoBehaviour
{
    [SerializeField] bool setUnavailable;
    [SerializeField] GameObject[] chairArray;
    [SerializeField] int availableChairs;
    
    void Awake()
    {
        chairArray = GameObject.FindGameObjectsWithTag("Chair");
        availableChairs = chairArray.Length;
        if (setUnavailable)
        {
            foreach (GameObject chair in chairArray)
            {
                chair.GetComponent<ChairStatus>().SetOccupied();
            }
        }
    }

    public void IncreaseAvailableChairs()
    {
        availableChairs++;
    }

    public void DecreaseAvailableChairs()
    {
        availableChairs--;
    }

    public GameObject[] GetChairArray()
    {
        return chairArray;
    }

    public int GetAvailableChairs()
    {
        return availableChairs;
    }
}
