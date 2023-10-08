using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    public TMP_Text healthText; // Cambia de Text a TMP_Text

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

    public void TakeDamage(int damage)
    {
        if (gameManager.IsGameOver)
        {
            return;
        }

        currentHealth -= damage;
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
        else
        {
            Debug.LogWarning("El componente 'TextMeshProUGUI' de salud no está asignado en el inspector.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }
}
