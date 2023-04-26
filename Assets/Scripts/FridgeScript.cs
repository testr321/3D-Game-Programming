using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeScript : MonoBehaviour
{
    [SerializeField] GameObject item1Prefab;
    [SerializeField] GameObject item2Prefab;
    [SerializeField] GameObject item3Prefab;
    [SerializeField] GameObject Shelf1Hitbox;
    [SerializeField] GameObject Shelf2Hitbox;
    [SerializeField] GameObject Shelf3Hitbox;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 4; i++)
            SpawnObject(i);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObject(int shelfNumber)
    {
        switch (shelfNumber)
        {
            case 1:
                if (item1Prefab != null)
                    Instantiate(item1Prefab, Shelf1Hitbox.transform.position, Quaternion.identity);
                break;
            case 2:
                if (item2Prefab != null)
                    Instantiate(item2Prefab, Shelf2Hitbox.transform.position, Quaternion.identity);
                break;
            case 3:
                if (item3Prefab != null)
                    Instantiate(item3Prefab, Shelf2Hitbox.transform.position, Quaternion.identity);
                break;
            default:
                Debug.Log("Shelf Number does not exist");
                break;

        }
    }
}
