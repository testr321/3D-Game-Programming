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
    bool holding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("PlayerPickUpDrop: GetMouseButton");
            float pickUpDistance = 2f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                { 
                    holding = true;
                    if (raycastHit.transform.TryGetComponent(out plateScript))
                    {
                        plateScript.PickUpItems();
                    }
                    if (objectGrabbable.gameObject.TryGetComponent(out FixedJoint fixedJoint))
                    {
                        fixedJoint.connectedBody.gameObject.GetComponent<PlateScript>().DetachItem(objectGrabbable.gameObject);
                        Destroy(objectGrabbable.gameObject.GetComponent<FixedJoint>());
                    }
                    objectGrabbable.Grab(objectGrabPointTransform);
                    Debug.Log("PlayerPickUpDrop: " + objectGrabbable);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
        // if (plateScript != null)
        //     {
        //         plateScript.DropItems();
                
        //     }
            holding = false;
            if (objectGrabbable == null)
                return;
            plateScript = null;
            objectGrabbable.Drop();
            objectGrabbable = null;
        }
    }

    public bool IsHolding()
    {
        return holding;
    }
}
