using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 10; 
    public float bulletSpeed = 10f; 
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 bulletDirection = transform.forward;

        rb.velocity = bulletDirection * bulletSpeed;

        Destroy(gameObject, 3f); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
