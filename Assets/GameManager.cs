using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text levelText;
    public TMP_Text timeText;
    public TMP_Text enemiesText;
    public TMP_Text playerHealthText;
    public GameObject enemySpawnPoint;

    public int currentLevel = 1;
    public float timeElapsed = 0f;
    public int enemiesKilled = 0;
    public int playerHealth = 100;


    public bool gameEnded = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseEnemiesKilled()
    {
        enemiesKilled++;
    }

    public void UpdatePlayerHealth(int health)
    {
        playerHealth = health;
        playerHealthText.text = "Vida: " + playerHealth;

        if (playerHealth <= 0)
        {
            PlayerDefeated();
        }
    }

    private void Update()
    {
        if (!gameEnded)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= 10f)
            {
                currentLevel++;
                timeElapsed = 0f;
                SpawnObjectOnNavMesh();

            }
            levelText.text = "Nivel: " + currentLevel;
            timeText.text = "Tiempo: " + Mathf.FloorToInt(timeElapsed) + "s";
            enemiesText.text = "Enemigos: " + enemiesKilled;
            playerHealthText.text = "Vida: " + playerHealth;

            if (currentLevel >= 10 || enemiesKilled >= 100 || playerHealth <= 0)
            {
                EndGame();
            }
        }
    }
    private void SpawnObjectOnNavMesh()
    {
        if (enemySpawnPoint != null)
        {
            // Aquí puedes generar el objeto en el NavMesh en la posición de "EnemySpawnPoint"
            Vector3 spawnPosition = enemySpawnPoint.transform.position;
             Instantiate(enemySpawnPoint, spawnPosition, Quaternion.identity);
        }
    }

    public void PlayerDefeated()
    {
        gameEnded = true;
        EndGame();
    }

    private void EndGame()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene("Win");
        }
    }
}


