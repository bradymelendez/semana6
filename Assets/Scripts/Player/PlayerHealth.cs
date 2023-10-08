using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Salud máxima del jugador.
    private int currentHealth; // Salud actual del jugador.

    public Text healthText; // Referencia al texto para mostrar la salud en UI.

    private GameManager gameManager; // Referencia al GameManager.

    private void Awake()
    {
        // Obtener la referencia al GameManager.
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud actual con el valor máximo.
        UpdateHealthUI(); // Actualizar la UI de salud al inicio.
    }

    public void TakeDamage(int damage)
    {
        // Verificar si el juego ya terminó (jugador derrotado).
        if (gameManager.IsGameOver)
        {
            return;
        }

        // Reducir la salud del jugador según el daño recibido.
        currentHealth -= damage;

        // Actualizar la salud del jugador en el GameManager.
        gameManager.UpdatePlayerHealth(currentHealth);

        // Verificar si el jugador ha quedado sin salud.
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Asegurarse de que la salud no sea negativa.

            // El jugador ha sido derrotado, notificar al GameManager.
            gameManager.PlayerDefeated();
        }

        UpdateHealthUI(); // Actualizar la UI de salud después de recibir daño.
    }

    private void UpdateHealthUI()
    {
        // Actualizar el texto de la salud en la UI (si tienes un objeto de texto para mostrar la salud).
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
