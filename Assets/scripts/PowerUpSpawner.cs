using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;  // Array of power-up prefabs
    public Transform mazeWallsParent;    // Parent object containing all walls
    public int maxPowerUps = 5;          // Max number of power-ups at once
    public float spawnInterval = 5f;     // Time between spawns
    public float powerUpHeight = 0.5f;   // Y position for power-ups
    public float spawnCheckRadius = 0.5f; // Radius to check if position is valid

    private float minX, maxX, minZ, maxZ;
    private LayerMask wallLayer;  // Layer mask to identify walls

    void Start()
    {
        // Define the bounds of the plane based on its scale
        Vector3 planeCenter = new Vector3(450.9969f, 0, -377.9281f);
        Vector3 planeScale = new Vector3(31.59124f, 1, 29.64283f);

        minX = planeCenter.x - (planeScale.x * 5f);
        maxX = planeCenter.x + (planeScale.x * 5f);
        minZ = planeCenter.z - (planeScale.z * 5f);
        maxZ = planeCenter.z + (planeScale.z * 5f);

        // Get the layer mask for walls
        wallLayer = LayerMask.GetMask("Wall");

        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            if (GameObject.FindGameObjectsWithTag("PowerUp").Length < maxPowerUps)
            {
                Vector3 spawnPosition = GetValidSpawnPosition();
                if (spawnPosition != Vector3.zero)
                {
                    GameObject powerUp = Instantiate(
                        powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)],
                        spawnPosition,
                        Quaternion.identity
                    );
                    powerUp.tag = "PowerUp";
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetValidSpawnPosition()
    {
        for (int i = 0; i < 20; i++)  // Try up to 20 times to find a valid position
        {
            float x = Mathf.Round(Random.Range(minX, maxX));
            float z = Mathf.Round(Random.Range(minZ, maxZ));

            Vector3 spawnPos = new Vector3(x, powerUpHeight, z);

            // Check if the spawn position is inside a wall using Physics Overlap
            if (!Physics.CheckSphere(spawnPos, spawnCheckRadius, wallLayer))
            {
                return spawnPos;
            }
        }
        return Vector3.zero;  // Return invalid position if no valid spot is found
    }
}
