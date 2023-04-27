using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] Transform playerCameraTransform;
    [SerializeField] Transform objectGrabPointTransform;
    [SerializeField] LayerMask pickUpLayerMask;

    ObjectGrabbable objectGrabbable;
    PlateScript plateScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float pickUpDistance = 2f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                {
                    if (raycastHit.transform.TryGetComponent(out plateScript))
                    {
                        plateScript.PickUpItems();
                    }
                    objectGrabbable.gameObject.transform.parent = null;
                    // Vector3 newLocalPosition = objectGrabbable.gameObject.transform.localPosition;
                    // newLocalPosition.y -= 1f;
                    // objectGrabbable.gameObject.transform.localPosition = newLocalPosition;
                    objectGrabbable.Grab(objectGrabPointTransform);
                    Debug.Log("PlayerPickUpDrop: " + objectGrabbable);
                }
            }
        }
        else if (objectGrabbable != null)
        {
            // if (plateScript != null)
            //     {
            //         plateScript.DropItems();
                    
            //     }
                plateScript = null;
                objectGrabbable.Drop();
                objectGrabbable = null;
        }
    }
}
