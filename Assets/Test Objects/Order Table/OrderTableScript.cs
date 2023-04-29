using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderTableScript : MonoBehaviour
{
    [SerializeField] BoxCollider placeItemsBoxCollider;
    [SerializeField] MenuScriptableObject menu;
    [SerializeField] TextMeshProUGUI orderText;
    [SerializeField] PlayerPickUpDrop playerPickUpDrop;
    
    // Start is called before the first frame update
    void Start()
    {
        RandomOrder();
        int i = 0;
        foreach (GameObject go in order)
        {
            orderText.text += order[i].name + "\n";
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerPickUpDrop.IsHolding())
            TestForItems();
    }

    void TestForItems()
    {
        // Debug.Log("OrderTableScript: TestForItems");
        Collider[] colliderArray = Physics.OverlapBox(
            transform.position + placeItemsBoxCollider.center,
            placeItemsBoxCollider.size/2f,
            placeItemsBoxCollider.transform.rotation);

        List<GameObject> itemsOnPlate = new List<GameObject>();
        // GameObject plate = null;
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out PlateScript plateScript))
            {
                // plate = collider.gameObject;
                itemsOnPlate = plateScript.GetItemsOnPlate();
            }
        }
        
        foreach (GameObject gameObject in itemsOnPlate)
        {
            Debug.Log(gameObject);
            Destroy(gameObject);
        }
        
        // if (plate != null)
        //     Destroy(plate);
    }

    List<GameObject> order = new List<GameObject>();
    void RandomOrder()
    {
        order.Add(menu.items[0]);
    }
}