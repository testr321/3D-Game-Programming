using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] GameObject npcPrefab;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Quaternion spawnRotation;
    [SerializeField] float spawnTime;
    float remainingTime = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (LevelChanger.isChangingScene)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Instantiate(npcPrefab, spawnPosition, spawnRotation);
        }
            
        if (remainingTime <= 0)
        {
            Instantiate(npcPrefab, spawnPosition, spawnRotation);
            remainingTime = spawnTime;
        }

        remainingTime -= Time.deltaTime;
    }
}
