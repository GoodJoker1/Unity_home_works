using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;
    public int coins = 0;
    public TextMeshProUGUI healthText;
    public Transform spawnPoint;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Respawn(); 
        }
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  
        UpdateHealthUI();
        Debug.Log("Player HP: " + currentHealth);
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        Debug.Log("Player healed, Health: " + currentHealth);
    }

    private void Respawn()
    {
        currentHealth = maxHealth;

        UpdateHealthUI();

        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        Debug.Log("Player respawned with full health at spawn point!");
    }

    public void IncreaseDamage(int additionalDamage)
    {
        RayShooter rayShooter = GetComponentInChildren<RayShooter>();
        if (rayShooter != null)
        {
            rayShooter.damage += additionalDamage;
            Debug.Log("Damage increased to: " + rayShooter.damage);
        }
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
