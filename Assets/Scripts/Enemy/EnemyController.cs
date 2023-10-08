using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100; 
    //public int damage = 10; 
    public int currentHealth;


    private GameManager gameManager; 
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        currentHealth = maxHealth; 
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }
    private void Update()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletController bullet = collision.gameObject.GetComponent<BulletController>();

            if (bullet != null)
            {
                TakeDamage(bullet.damage);
                Destroy(collision.gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameManager.IncreaseEnemiesKilled();
            Destroy(gameObject);
        }
    }
}
