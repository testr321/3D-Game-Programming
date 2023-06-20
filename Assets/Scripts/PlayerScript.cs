using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] int health = 1;
    [SerializeField] HeartUIScript heartUIScript;
    [SerializeField] TextMeshProUGUI customerServedText;
    
    int consecutiveCustomersServed;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        customerServedText.text = score.ToString();
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
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (health >= maxHealth)
                return;
            health++;
            heartUIScript.UpdateUI();
        }

        if (consecutiveCustomersServed >= 10)
        {
            consecutiveCustomersServed = 0;
            health++;
            heartUIScript.UpdateUI();
        }

        if (health == 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("End Game");
    }

    public void CustomerServed()
    {
        consecutiveCustomersServed++;
        score++;
        customerServedText.text = score.ToString();
    }

    public void CustomerLeft()
    {
        consecutiveCustomersServed = 0;
        health--;
        heartUIScript.UpdateUI();
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
