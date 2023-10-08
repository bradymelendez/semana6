using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Referencia estática al GameManager.

    public Text levelText;
    public Text timeText;
    public Text enemiesText;
    public Text playerHealthText;

    public int currentLevel = 1;
    public float timeElapsed = 0f;
    public int enemiesKilled = 0;
    public int playerHealth = 100;

    public bool IsGameOver { get; private set; } // Variable de estado del juego.

    private void Awake()
    {
        // Configura la referencia estática.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta.
        }
    }

    private void Update()
    {
        if (!IsGameOver)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= 10f)
            {
                currentLevel++;
                timeElapsed = 0f;
                // Aumentar la velocidad de disparo del jugador y otras actualizaciones de nivel aquí.
            }

            // Actualizar la interfaz de usuario con los datos actuales.
            levelText.text = "Nivel: " + currentLevel;
            timeText.text = "Tiempo: " + Mathf.FloorToInt(timeElapsed) + "s";
            enemiesText.text = "Enemigos: " + enemiesKilled;
            playerHealthText.text = "Vida: " + playerHealth;

            // Agregar lógica para verificar las condiciones de victoria y derrota aquí.
            if (currentLevel >= 10 || enemiesKilled >= 100 || playerHealth <= 0)
            {
                EndGame();
            }
        }
    }

    public void UpdatePlayerHealth(int health)
    {
        playerHealth = health;
        playerHealthText.text = "Vida: " + playerHealth;
    }

    public void PlayerDefeated()
    {
        IsGameOver = true;
        EndGame(); // Llamar a EndGame cuando el jugador sea derrotado.
    }

    private void EndGame()
    {
        // Agregar aquí la lógica para finalizar el juego, mostrar la pantalla de derrota o victoria, etc.
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene"); // Cambiar al nombre de tu escena de derrota.
        }
        else
        {
            SceneManager.LoadScene("WinScene"); // Cambiar al nombre de tu escena de victoria.
        }
    }
}

