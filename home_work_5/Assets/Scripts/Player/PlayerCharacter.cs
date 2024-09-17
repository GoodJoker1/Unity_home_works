using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI healthText; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  
        UpdateHealthUI();
        Debug.Log("Player HP: " + currentHealth);
    }

    private void UpdateHealthUI()
    {
        healthText.text = "HP: " + currentHealth;
        if (currentHealth > maxHealth / 2)
        {
            healthText.color = Color.green;
        }
        else if (currentHealth < maxHealth * 0.1f && currentHealth > 1)
        {
            healthText.color = Color.yellow;
        }
        else
        {
            healthText.color = Color.red;
        }
    }
}
