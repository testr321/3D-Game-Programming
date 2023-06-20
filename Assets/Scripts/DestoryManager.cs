using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryManager : MonoBehaviour
{
    // [SerializeField] List<GameObject> NPCList;
    [SerializeField] Vector3 exitPosition;

    // public int AddToQueue(GameObject gameObject)
    // {
    //     NPCList.Add(gameObject);
    //     return NPCList.Count;
    // }

    public Vector3 GetExitPosition()
    {
        return exitPosition;
    }

    // public void RemoveFromList(GameObject gameObject)
    // {
    //     foreach (GameObject NPC in NPCList)
    //     {
    //         if (NPC == gameObject)
    //         {
    //             NPCList.Remove(gameObject);
    //             break;
    //         }
    //     }
    // }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
