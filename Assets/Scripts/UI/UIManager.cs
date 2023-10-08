using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text levelText; // Cambia de Text a TMP_Text
    public TMP_Text timeText; // Cambia de Text a TMP_Text
    public TMP_Text enemiesText; // Cambia de Text a TMP_Text
    public TMP_Text playerHealthText; // Cambia de Text a TMP_Text
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        // Actualizar la interfaz de usuario con los datos del GameManager.
        levelText.text = "Nivel: " + gameManager.currentLevel;
        timeText.text = "Tiempo: " + Mathf.FloorToInt(gameManager.timeElapsed) + "s";
        enemiesText.text = "Enemigos: " + gameManager.enemiesKilled;
        playerHealthText.text = "Vida: " + gameManager.playerHealth;
    }
}
