using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    public new string name;
    public bool plateItem;
    public bool foodItem;
    public float cookTime;
    public Material cookedMaterial;
    float range;
    Rigidbody rb;
    Transform objectGrabPointTransform;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!foodItem)
            return;

        range = gameObject.transform.localScale.y * 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!foodItem)
            return;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down * range), out RaycastHit raycastHit, range))
        {
            if (raycastHit.transform.gameObject.tag == "Stove")
            {
                cookTime -= Time.deltaTime;
                Debug.Log("Cooking");
            }
        }

        if (cookTime <= 0)
        {
            gameObject.GetComponent<Renderer>().material = cookedMaterial;
            // Debug.Log("Done Cooking");
        }
    }

    void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 20f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            rb.MovePosition(newPosition);
        }
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        rb.useGravity = true;
        rb.isKinematic = false;
    }
}
