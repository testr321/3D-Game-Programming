using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] int health = 1;
    [SerializeField] HeartUIScript heartUIScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            if (health <= 0)
                return;
            health--;
            heartUIScript.UpdateUI();
            if (health == 0)
            {
                Debug.Log("End Game");
            }
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (health >= maxHealth)
                return;
            health++;
            heartUIScript.UpdateUI();
        }
    }

    public int GetMaxHealth()
    {
        return (maxHealth);
    }

    public int GetHealth()
    {
        return (health);
    }
}
