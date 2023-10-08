using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100; // Salud m�xima del enemigo.
    public int damage = 10; // Cantidad de da�o que hace el enemigo al jugador.
    public int currentHealth; // Salud actual del enemigo.

    private GameManager gameManager; // Referencia al GameManager.
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private void Awake()
    {
        // Obtener la referencia al GameManager.
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud actual con el valor m�ximo.
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Aseg�rate de que el jugador tenga el tag "Player".
    }
    private void Update()
    {
        // Configura la posici�n del destino del NavMeshAgent hacia el jugador.
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisi�n involucra una bala (objeto con el tag "Bullet").
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Obtener el componente BulletController de la bala.
            BulletController bullet = collision.gameObject.GetComponent<BulletController>();

            // Verificar si se obtuvo el componente BulletController.
            if (bullet != null)
            {
                // Aplicar da�o al enemigo seg�n el da�o de la bala.
                TakeDamage(bullet.damage);

                // Destruir la bala.
                Destroy(collision.gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        // Reducir la salud del enemigo seg�n el da�o recibido.
        currentHealth -= damage;

        // Verificar si el enemigo ha quedado sin salud.
        if (currentHealth <= 0)
        {
            // El enemigo ha sido derrotado, puedes realizar acciones adicionales aqu�.
            // Por ejemplo, destruir el GameObject del enemigo.
            Destroy(gameObject);
        }
    }
}
