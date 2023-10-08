using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 10; // Cantidad de da�o que hace la bala.
    public float bulletSpeed = 10f; // Velocidad de la bala.

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Obtener la direcci�n de disparo (por ejemplo, hacia adelante en la direcci�n de rotaci�n del GameObject).
        Vector3 bulletDirection = transform.forward;

        // Aplicar una velocidad inicial a la bala en la direcci�n de disparo.
        rb.velocity = bulletDirection * bulletSpeed;

        // Destruir la bala despu�s de un tiempo si no colisiona con nada.
        Destroy(gameObject, 3f); // Por ejemplo, destruir la bala despu�s de 3 segundos.
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisi�n involucra un objeto con el tag "Enemy".
        if (other.CompareTag("Enemy"))
        {
            // Obtener una referencia al script EnemyController del enemigo.
            EnemyController enemy = other.GetComponent<EnemyController>();

            // Aplicar da�o al enemigo si se encuentra el componente EnemyController.
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Destruir la bala al colisionar con un enemigo.
            Destroy(gameObject);
        }
    }
}
