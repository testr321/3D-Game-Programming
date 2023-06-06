using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npc;
    public float spawnTime = 5f;
    private float remTime = 0f;

    void Start()
    {
        GameObject newNPC = Instantiate(npc);
    }

    void Update()
    {
        if (remTime > spawnTime)
        {
            GameObject newNPC = Instantiate(npc);

            remTime = 0;
        }

        remTime += Time.deltaTime;
    }
}
