using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderScript : MonoBehaviour
{
    public bool testing;
    [SerializeField] BoxCollider placeItemsBoxCollider;
    [SerializeField] MenuItemsScriptableObject menu;
    [SerializeField] TextMeshProUGUI orderText;
    [SerializeField] AudioSource src;

    NPCController npcController;
    PlayerPickUpDrop playerPickUpDrop;

    //List incase impliment multiple orders
    List<FoodItemScriptableObject> orders = new List<FoodItemScriptableObject>();

    void Awake()
    {
        npcController = GetComponentInParent<NPCController>();
        playerPickUpDrop = FindObjectOfType<PlayerPickUpDrop>();
        orderText.text = null;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        RandomOrder();
        int i = 0;
        foreach (FoodItemScriptableObject go in orders)
        { 
            orderText.text += orders[i].name + "\n";
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelChanger.isChangingScene)
            return;
            
        testing = false;
        orderText.gameObject.SetActive(npcController.isSeated());

        if (!playerPickUpDrop.IsHolding() && npcController.isSeated())
        {
            testing = true;
            TestForItems();
        }
    }

    void TestForItems()
    {
        bool complete = false;
        List<GameObject> itemsOnPlate = null;

        Collider[] colliderArray = Physics.OverlapBox(
            transform.position + transform.TransformDirection(Vector3.Scale(placeItemsBoxCollider.center, transform.lossyScale)),
            Vector3.Scale(placeItemsBoxCollider.size, transform.lossyScale / 3), 
            placeItemsBoxCollider.transform.rotation);

        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out PlateScript plateScript))
            {
                itemsOnPlate = plateScript.GetItemsOnPlate();
            }
        }

        if (itemsOnPlate == null)
            return;

        if (src != null)
        {
            src.Play();
        }

        foreach (FoodItemScriptableObject order in orders)
        {
            if (order.items.Length == itemsOnPlate.Count - 1)
            {
                Debug.Log("Order Length: " + order.items.Length);
                Debug.Log("Plate Length: " + itemsOnPlate.Count);
                List<GameObject> temp;
                for (int i = 0; i < order.items.Length; i++)
                {
                    Debug.Log("Order: " + order.items[i]);
                    temp = new List<GameObject>();

                    foreach (GameObject item in itemsOnPlate)
                    {
                        ObjectGrabbable itemObjectGrabbable = item.GetComponent<ObjectGrabbable>();
                        Debug.Log("Item on plate: " + itemObjectGrabbable.name);
                        if (itemObjectGrabbable.name == "Plate")
                        {
                            Debug.Log("Skipped");
                            continue;
                        }
                        
                        Debug.Log("Order Cooked: " + order.cooked[i]);
                        Debug.Log("Item Cooked: " + itemObjectGrabbable.cooked);
                        if (order.items[i].GetComponent<ObjectGrabbable>().name == itemObjectGrabbable.name && order.cooked[i] == itemObjectGrabbable.cooked)
                        {
                            temp.Add(item);
                            Debug.Log("added item" + item);
                            continue;
                        }
                    }
                    RemoveFromList(itemsOnPlate, temp);
                }
                Debug.Log("Item on plate count: " + itemsOnPlate.Count);
                if (itemsOnPlate.Count == 1)
                    complete = true;
            }
            else
                Debug.Log("Item count dont match");

            npcController.UpdateOrderStatus(complete);
            
            foreach (GameObject gameObject in itemsOnPlate)
            {
                Destroy(gameObject);
            }
        }
    }

    void RandomOrder()
    {
        // foreach (FoodItemScriptableObject food in menu.items)
        //     Debug.Log(food);

        orders.Add(menu.items[Random.Range(0, menu.GetLen())]);
    }

    void RemoveFromList(List<GameObject> list, List<GameObject> removeList)
    {
        foreach (GameObject remove in removeList)
        {
            list.Remove(remove);
            Destroy(remove);
        }
    }

    private void OnDrawGizmos()
    {
        Color boxColor = Color.red;
        Vector3 center = transform.position + transform.TransformDirection(Vector3.Scale(placeItemsBoxCollider.center, transform.lossyScale));
        Quaternion rotation = placeItemsBoxCollider.transform.rotation;
        Vector3 size = Vector3.Scale(placeItemsBoxCollider.size, transform.lossyScale);

        Gizmos.color = boxColor;
        Gizmos.matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, size);
    }
}
