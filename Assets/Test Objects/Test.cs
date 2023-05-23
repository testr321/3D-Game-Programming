using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject[] chairArray;
    public Vector3[] chairLoc;
    public Quaternion[] chairRot;

    // Start is called before the first frame update
    void Awake()
    {
        chairArray = GameObject.FindGameObjectsWithTag("Chair");
        foreach (GameObject chair in chairArray)
        {
            // Debug.Log(chair.gameObject);
        }

        chairLoc = new Vector3[chairArray.Length];
        chairRot = new Quaternion[chairArray.Length];

        for (int i = 0; i < chairArray.Length; i++)
        {
            chairLoc[i] = chairArray[i].transform.position;
            chairRot[i] = chairArray[i].transform.rotation;
            Debug.Log(chairLoc[i]);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
