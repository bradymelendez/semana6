using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text levelText;
    public TMP_Text timeText;
    public TMP_Text enemiesText; 
    public TMP_Text playerHealthText; 
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        levelText.text = "Nivel: " + gameManager.currentLevel;
        timeText.text = "Tiempo: " + Mathf.FloorToInt(gameManager.timeElapsed) + "s";
        enemiesText.text = "Enemigos: " + gameManager.enemiesKilled;
        playerHealthText.text = "Vida: " + gameManager.playerHealth;
    }
}
