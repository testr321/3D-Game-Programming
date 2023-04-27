using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTrigger : MonoBehaviour
{
    [SerializeField] FridgeScript fScript;
    [SerializeField] int shelfNumber;
    [SerializeField] int count = 0;

    void Awake()
    {
        fScript = GetComponentInParent<FridgeScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out ObjectGrabbable objectGrabbable))
            return;
        count++;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out ObjectGrabbable objectGrabbable))
            return;
            
        count--;
        if (count == 0)
        {
            StartCoroutine(SpawnObject());
        }
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(3);
        if (count == 0)
            fScript.SpawnObject(shelfNumber);
    }
}
