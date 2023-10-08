using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text levelText;
    public Text timeText;
    public Text enemiesText;
    public Text playerHealthText;

    public int currentLevel = 1;
    public float timeElapsed = 0f;
    public int enemiesKilled = 0;
    public int playerHealth = 100;

    private bool gameEnded = false;
    private void Update()
    {
        if (!gameEnded)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= 10f)
            {
                currentLevel++;
                timeElapsed = 0f;
                // Aumentar la velocidad de disparo del jugador y otras actualizaciones de nivel aqu�.
            }

            // Actualizar la interfaz de usuario con los datos actuales.
            levelText.text = "Nivel: " + currentLevel;
            timeText.text = "Tiempo: " + Mathf.FloorToInt(timeElapsed) + "s";
            enemiesText.text = "Enemigos: " + enemiesKilled;
            playerHealthText.text = "Vida: " + playerHealth;

            // Agregar l�gica para verificar las condiciones de victoria y derrota aqu�.
            if (currentLevel >= 10 || enemiesKilled >= 100 || playerHealth <= 0)
            {
                EndGame();
            }
        }
    }
    public void PlayerHit(int damage)
    {
        if (!gameEnded)
        {
            playerHealth -= damage;
            // Actualizar la interfaz de usuario con la nueva vida del jugador.
            if (playerHealth <= 0)
            {
                EndGame();
            }
        }
    }
    private void EndGame()
    {
        gameEnded = true;
        // Agregar aqu� la l�gica para finalizar el juego, mostrar la pantalla de derrota o victoria, etc.
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
