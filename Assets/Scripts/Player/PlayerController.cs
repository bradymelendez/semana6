using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized; 
        Vector3 shootingDirection = movement;

        Vector3 currentPosition = transform.position;

        Vector3 newPosition = currentPosition + movement * speed * Time.deltaTime;

        transform.position = newPosition;

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot(shootingDirection);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);

        Instantiate(bulletPrefab, transform.position, rotation);
    }
}
