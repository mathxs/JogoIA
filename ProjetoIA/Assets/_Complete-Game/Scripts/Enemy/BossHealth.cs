using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class BossHealth : MonoBehaviour
    {
        // These are built static because there is only one boss spawn
        public static int startingHealth = 1000;        // Boss' starting health
        public static int currentHealth;                // Boss' current health
        EnemyHealth life;

        void Awake()
        {
            // Load boss' life based on the EnemyHealth script
            currentHealth = startingHealth;
            life = GetComponent<EnemyHealth>();
        }

        void Update()
        {
            // Keep the boss' health updated
            currentHealth = life.currentHealth;
        }
    }
}
