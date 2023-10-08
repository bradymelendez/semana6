using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int initialHealth = 100;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.playerHealth = initialHealth;
    }

    public void TakeDamage(int damage)
    {
        gameManager.PlayerHit(damage);
    }
}
