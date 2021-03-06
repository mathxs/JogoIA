﻿using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        private bool unico;

        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating("Spawn", spawnTime, spawnTime);
            unico = true;
        }

        private void Update()
        {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            if (ScoreManager.boss)
            {
                if (unico)
                {
                    Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                    unico = false;
                }
                else
                {
                    return;
                }
            }
        }

        void Spawn ()
        {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            // If the player has no health left...
            if (playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.

            if (unico)
            {
                Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
        }
    }
}