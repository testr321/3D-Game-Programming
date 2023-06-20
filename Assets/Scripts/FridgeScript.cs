using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeScript : MonoBehaviour
{
    [SerializeField] GameObject[] itemsPrefabArray;
    [SerializeField] GameObject[] ShelfHitboxArray;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= itemsPrefabArray.Length; i++)
            SpawnObject(i); 
    }

    public void SpawnObject(int shelfNumber)
    {
        if (itemsPrefabArray[shelfNumber - 1] != null)
            Instantiate(itemsPrefabArray[shelfNumber - 1], ShelfHitboxArray[shelfNumber - 1].transform.position, itemsPrefabArray[shelfNumber - 1].transform.rotation);
    }
}
