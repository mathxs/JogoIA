using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class BossHealth : MonoBehaviour
    {
        public static int startingHealth = 1000;
        public static int currentHealth;
        EnemyHealth life;

        void Awake()
        {
            currentHealth = startingHealth;
            life = GetComponent<EnemyHealth>();
        }

        void Update()
        {
            currentHealth = life.currentHealth;
        }
    }
}
