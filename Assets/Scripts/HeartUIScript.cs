using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUIScript : MonoBehaviour
{
    [SerializeField] Texture2D heartImage;
    [SerializeField] Vector3 heartPosition;
    [SerializeField] GameObject[] heartList;

    PlayerScript playerScript;
    void Awake()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        int maxHealth = playerScript.GetMaxHealth();
        int health = playerScript.GetHealth();

        heartList = new GameObject[maxHealth];

        for (int i = 0; i < maxHealth; i++)
        {
            heartPosition.x += 50f;

            GameObject heartGameObject = new GameObject("Heart " + (i + 1));
            heartGameObject.SetActive(false);

            heartGameObject.AddComponent<RawImage>();
            heartGameObject.GetComponent<RawImage>().texture = heartImage;

            heartGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            heartGameObject.transform.SetParent(gameObject.transform);
            heartGameObject.transform.localPosition = heartPosition;
            heartList[i] = gameObject.transform.GetChild(i).gameObject;
            if (i < health)
                heartGameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        int maxHealth = playerScript.GetMaxHealth();
        int health = playerScript.GetHealth();

        // Debug.Log(health);
        for (int i = 0; i < maxHealth; i++)
        {
            if (i < health)
                heartList[i].SetActive(true);
            else
                heartList[i].SetActive(false);
        }
    }
}
