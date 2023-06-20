using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QueueManager : MonoBehaviour
{
    [SerializeField] List<GameObject> NPCList;
    [SerializeField] Vector3 queuePosition;

    public int AddToQueue(GameObject gameObject)
    {
        NPCList.Add(gameObject);
        queuePosition.z += 1;
        return NPCList.Count - 1;
    }

    public void ChairAvailable(GameObject chair)
    {
        if (GetQueueLength() <= 0)
            return;

        NPCList[0].GetComponent<NPCController>().SetChair(chair);
        NPCList.Remove(NPCList[0]);
        queuePosition.z -= 1;

        for (int i = 0; i < NPCList.Count; i++)
        {
            NPCList[i].GetComponent<NPCController>().MoveForwardInQueue(i);
        }
    }

    public void RemoveFromList(GameObject gameObject)
    {
        bool inList = false;

        foreach (GameObject NPC in NPCList)
        {
            if (NPC == gameObject)
            {
                NPCList.Remove(gameObject);
                inList = true;
                break;
            }
        }

        if (inList)
        {
            for (int i = 0; i < NPCList.Count; i++)
            {
                NPCList[i].GetComponent<NPCController>().MoveForwardInQueue(i);
            }
        }
    }

    public Vector3 GetQueuePosition()
    {
        return queuePosition;
    }

    public int GetQueueLength()
    {
        return NPCList.Count;
    }
}
