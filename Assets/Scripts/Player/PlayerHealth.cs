using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; 
    public int currentHealth; 
    public TMP_Text healthText; 

    private GameManager gameManager; 

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        currentHealth = maxHealth; 
        UpdateHealthUI(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); 
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (gameManager == null)
        {
            return;
        }

        gameManager.UpdatePlayerHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0; 
            gameManager.PlayerDefeated();
        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
