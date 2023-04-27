using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] BoxCollider placeItemsBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpItems()
    {
        Debug.Log("PlateScript: PickUpItems");
        Collider[] colliderArray = Physics.OverlapBox(
            transform.position + placeItemsBoxCollider.center, 
            placeItemsBoxCollider.size/2f, 
            placeItemsBoxCollider.transform.rotation);

        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out ObjectGrabbable objectGrabbable))
            {
                if (!objectGrabbable.plateItem && objectGrabbable.gameObject.transform.parent == null)
                {
                    collider.attachedRigidbody.useGravity = false;
                    collider.attachedRigidbody.isKinematic = true;
                    collider.transform.parent = gameObject.transform;
                    Vector3 newLocalPosition = collider.transform.localPosition;
                    newLocalPosition.y += 0.1f;
                    collider.transform.localPosition = newLocalPosition;
                    Debug.Log("PlateScript: " + collider);
                }
            }
        }
    }

    public void DropItems()
    {
        Debug.Log("PlateScript: DropItems");
        // gameObject.transform.DetachChildren();
    }
}
