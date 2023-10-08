using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomNavMeshPointGenerator : MonoBehaviour
{
    public GameObject objectToSpawn; 
    public float spawnInterval = 10f; 

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        { 
            Vector3 randomPosition = GetRandomNavMeshPosition();

            if (randomPosition != Vector3.zero)
            {

                Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            }
            timer = 0f;
        }
    }

    private Vector3 GetRandomNavMeshPosition()
    {
        UnityEngine.AI.NavMeshHit hit;
        Vector3 randomPosition = Vector3.zero;
        for (int i = 0; i < 30; i++) 
        {
            Vector3 randomDirection = Random.insideUnitSphere * 10f; 
            randomDirection += transform.position; 

            if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, 10f, UnityEngine.AI.NavMesh.AllAreas))
            {
                randomPosition = hit.position;
                break;
            }
        }
        return randomPosition;
    }
}
