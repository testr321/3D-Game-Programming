using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] BoxCollider placeItemsBoxCollider;
    List<GameObject> itemsOnPlate = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        itemsOnPlate.Add(gameObject);
    }

    public void PickUpItems()
    {
        // Debug.Log("PlateScript: PickUpItems");
        Collider[] colliderArray = Physics.OverlapBox(
            transform.position + placeItemsBoxCollider.center,
            placeItemsBoxCollider.size / 2, 
            placeItemsBoxCollider.transform.rotation);

        // Debug.Log("PlateScript :" + colliderArray.Length);
        foreach (Collider collider in colliderArray)
        {
            // Debug.Log("PlateScript :" + collider.transform);
            if (collider.TryGetComponent(out ObjectGrabbable objectGrabbable))
            {
                if (!objectGrabbable.plateItem && !collider.TryGetComponent(out FixedJoint fixedJoint))
                {
                    itemsOnPlate.Add(collider.gameObject);
                    collider.gameObject.AddComponent<FixedJoint>();
                    collider.gameObject.GetComponent<FixedJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
                }
            }
        }
    }

    public void DropItems()
    {
        // Debug.Log("PlateScript: DropItems");
        // gameObject.transform.DetachChildren();
    }
    
    public void DetachItem(GameObject gameObject)
    {
        itemsOnPlate.Remove(gameObject);
    }

    public List<GameObject> GetItemsOnPlate()
    {
        return (itemsOnPlate);
    }

    private void OnDrawGizmos()
    {
        Color boxColor = Color.red;
        Vector3 center = transform.position + placeItemsBoxCollider.center;
        Quaternion rotation = placeItemsBoxCollider.transform.rotation;
        Vector3 size = placeItemsBoxCollider.size;

        Gizmos.color = boxColor;
        Gizmos.matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, size);
    }
}
