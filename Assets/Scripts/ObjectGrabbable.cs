using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    public new string name;
    [SerializeField] float range;
    [SerializeField] float cookedTimer;
    [SerializeField] float cookTime;
    [SerializeField] float burnTime;
    [SerializeField] Material rawMaterial;
    [SerializeField] Material cookedMaterial;
    [SerializeField] Material burnedMaterial;
    [SerializeField] AudioSource src;
    new ParticleSystem particleSystem;

    
    public bool plateItem;
    public bool foodItem;
    public bool cooked;

    bool playing;
    bool cooking;
    Rigidbody rb;
    Transform objectGrabPointTransform;

    void Awake()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody>();

        if (src != null && particleSystem != null)
        {
            src.Stop();
            particleSystem.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelChanger.isChangingScene)
            return;
            
        if (!foodItem)
            return;
        
        if (cooking)
        {
            cookedTimer += Time.deltaTime;
        }

        // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down * range));
        // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down * range), out RaycastHit raycastHit, range))
        // {
        //     if (raycastHit.transform.gameObject.tag == "Stove")
        //     {
        //         if (!playing && src != null && particleSystem != null)
        //         {
        //             playing = true;
        //             src.Play();
        //             particleSystem.Play();
        //         }
        //     }
        // }
        // else
        // {
        //     playing = false;
        //     src.Stop();
        //     particleSystem.Stop();
        // }

        if (cookedTimer >= burnTime && burnTime != -1)
        {
            cooked = false;

            if (burnedMaterial != null)
                gameObject.GetComponent<Renderer>().material = burnedMaterial;
        }
        else if (cookedTimer >= cookTime && cookTime != -1)
        {
            cooked = true;

            if (cookedMaterial != null)
                gameObject.GetComponent<Renderer>().material = cookedMaterial;
        }
        else
        {
            cooked = false;

            if (rawMaterial != null)
                gameObject.GetComponent<Renderer>().material = rawMaterial;
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

    public void StartCook()
    {
        cooking = true;
        if (src != null && particleSystem != null)
        {
            src.Play();
            particleSystem.Play();
        }
    }

    public void StopCook()
    {
        cooking = false;
        if (src != null && particleSystem != null)
        {
            src.Stop();
            particleSystem.Stop();
        }
    }
}
