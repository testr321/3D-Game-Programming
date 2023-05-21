using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject[] chairArray;
    public Vector3[] chairLoc;
    // Start is called before the first frame update
    void Start()
    {
        chairArray = GameObject.FindGameObjectsWithTag("Chair");
        foreach (GameObject chair in chairArray)
        {
            // Debug.Log(chair.gameObject);
        }

        chairLoc = new Vector3[chairArray.Length];

        for(int i = 0; i < chairArray.Length; i++)
        {
            chairLoc[i] = chairArray[i].transform.position;
            Debug.Log(chairLoc[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
