using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject[] chairArray;
    // Start is called before the first frame update
    void Start()
    {
        chairArray = GameObject.FindGameObjectsWithTag("Chair");
        foreach (GameObject chair in chairArray)
        {
            // Debug.Log(chair.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
