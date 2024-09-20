using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReactiveTarget : MonoBehaviour
{
    private int hitPoints = 10;
    public int coinsReward = 10;
    private enum EnemyState { Alive, Wounded, Dead };
    private EnemyState currentState = EnemyState.Alive;
    public TextMeshProUGUI healthText;

    void Start()
    {
        UpdateHealthText(); 
    }

    public void ReactToHit(int damage) {
        if (currentState == EnemyState.Dead) return;

        hitPoints -= damage;

        if(hitPoints > 0 && hitPoints <= 5)
        {
            currentState = EnemyState.Wounded;
            Debug.Log("The enemy has been wounded! Remaining life points: " + hitPoints);
        }
        else if(hitPoints <= 0)
        {
            WanderingAI behavior = GetComponent<WanderingAI>();
            if (behavior != null)
            {
                behavior.SetAlive(false);
            }

            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                PlayerCharacter playerCharacter = player.GetComponent<PlayerCharacter>();
                if (playerCharacter != null)
                {
                    playerCharacter.AddCoins(coinsReward);
                }
            }

            Debug.Log("The enemy has been killed!");
            StartCoroutine(Die());
        }

        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "HP: " + hitPoints; 
        if (hitPoints > 5)
        {
            healthText.color = Color.green;  
        }
        else if (hitPoints > 0)
        {
            healthText.color = Color.yellow;
        }
        else
        {
            healthText.color = Color.red; 
        }
    }
    private IEnumerator Die() {
        this.transform.Rotate(-75, 0, 0); 
        yield return new WaitForSeconds(1.5f); 
        Destroy(this.gameObject); 
    }
}