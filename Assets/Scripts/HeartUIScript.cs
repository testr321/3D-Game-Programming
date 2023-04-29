using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUIScript : MonoBehaviour
{
    [SerializeField] PlayerScript pScript;
    [SerializeField] Texture2D heartImage;
    [SerializeField] GameObject[] heartList;

    void Awake()
    {
        int maxHealth = pScript.GetMaxHealth();
        int health = pScript.GetHealth();

        heartList = new GameObject[maxHealth];
        Vector3 pos = new Vector3(0f, -50f, 0f);

        for (int i = 0; i < maxHealth; i++)
        {
            pos.x += 50f;

            GameObject heartGameObject = new GameObject("Heart " + (i + 1));
            heartGameObject.SetActive(false);

            heartGameObject.AddComponent<RawImage>();
            heartGameObject.GetComponent<RawImage>().texture = heartImage;

            heartGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            heartGameObject.transform.SetParent(gameObject.transform);
            heartGameObject.transform.localPosition = pos;
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
        int maxHealth = pScript.GetMaxHealth();
        int health = pScript.GetHealth();

        Debug.Log(health);
        for (int i = 0; i < maxHealth; i++)
        {
            if (i < health)
                heartList[i].SetActive(true);
            else
                heartList[i].SetActive(false);
        }
    }
}
