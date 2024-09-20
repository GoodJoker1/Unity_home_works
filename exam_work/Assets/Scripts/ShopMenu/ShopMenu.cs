using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject shopUI;  
    public TextMeshPro coinsText;     
    public PlayerCharacter player; 

    public int healthUpgradeCost = 20;
    public int damageUpgradeCost = 30;


    void Start()
    {
        shopUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            ToggleShop();
        }

        coinsText.text = "Coins: " + player.coins.ToString();
    }

    public void ToggleShop()
    {
        shopUI.SetActive(!shopUI.activeSelf);  
    }

    public void BuyHealthUpgrade()
    {
        if (player.coins >= healthUpgradeCost)
        {
            player.coins -= healthUpgradeCost;
            player.Heal(20);  
        }
        else
        {
            Debug.Log("Not enough coins for health upgrade.");
        }
    }

    public void BuyDamageUpgrade()
    {
        if (player.coins >= damageUpgradeCost)
        {
            player.coins -= damageUpgradeCost;
            player.IncreaseDamage(10);  
        }
        else
        {
            Debug.Log("Not enough coins for damage upgrade.");
        }
    }
}
