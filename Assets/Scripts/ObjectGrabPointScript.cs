using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabPointScript : MonoBehaviour
{
    // bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        
        
        if (!other.TryGetComponent(out ObjectGrabbable objectGrabbable))
        {
            // trigger = true;
            // Debug.Log("ObjectGrabPointScript: OnTriggerStay");
            
            Vector3 objectPosition = other.gameObject.transform.position;
            Vector3 grabPosition = gameObject.transform.position;
            Vector3 newGrabPosition = objectPosition - grabPosition;
            // gameObject.transform.localPosition -= newGrabPosition;
            // Debug.Log(objectPosition);
            // Debug.Log(grabPosition);
            Debug.Log(newGrabPosition);
            // Debug.Log(other.transform);
        }
        // gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
        // Debug.Log(other.transform);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out ObjectGrabbable objectGrabbable))
        {
            // trigger = false;
            // Debug.Log("ObjectGrabPointScript: OnTriggerExit");
            Vector3 defaultLocalPosition = Vector3.zero;
            defaultLocalPosition.z = 1.5f;
            gameObject.transform.localPosition = defaultLocalPosition;
        }
        
        // if (!other.TryGetComponent(out ObjectGrabbable objectGrabbable))
        // // gameObject.transform.position = new Vector3(0f, 0f, 0f);
        // Debug.Log(gameObject.transform.position);
        // Debug.Log(other.transform);
    }
}
