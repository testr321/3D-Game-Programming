using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderTableScript : MonoBehaviour
{
    [SerializeField] BoxCollider placeItemsBoxCollider;
    [SerializeField] MenuItemsScriptableObject menu;
    [SerializeField] TextMeshProUGUI orderText;
    [SerializeField] PlayerPickUpDrop playerPickUpDrop;
    List<FoodItemScriptableObject> order = new List<FoodItemScriptableObject>();

    
    // Start is called before the first frame update
    void Start()
    {
        RandomOrder();
        int i = 0;
        foreach (FoodItemScriptableObject go in order)
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

        List<GameObject> itemsOnPlate = null;
        // GameObject plate = null;
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out PlateScript plateScript))
            {
                itemsOnPlate = plateScript.GetItemsOnPlate();
            }
        }
        
        if (itemsOnPlate != null)
        {
            foreach (GameObject gameObject in itemsOnPlate)
            {
                Debug.Log(gameObject);
                Destroy(gameObject);
            }
            // foreach (GameObject gameObject in itemsOnPlate)
            //     Debug.Log(gameObject);
        }
        
        // if (plate != null)
        //     Destroy(plate);
    }

    void RandomOrder()
    {
        foreach (FoodItemScriptableObject food in menu.items)
            Debug.Log(food);

        order.Add(menu.items[Random.Range(0, menu.GetLen())]);
    }
}
