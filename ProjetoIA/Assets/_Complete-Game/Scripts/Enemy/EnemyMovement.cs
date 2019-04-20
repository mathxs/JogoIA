using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        private NavMeshAgent nav;        // Reference to the nav mesh agent.

        protected GameObject[] pointList;
        protected Vector3 destPos;
        protected bool curState;
        protected int status;
        public Transform inimigos;

        void Awake()
        {
            // Set up the references.
            //nav = GetComponent<NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            pointList = GameObject.FindGameObjectsWithTag("PatrolPoint");
            //inimigos = GameObject.FindGameObjectsWithTag("Shootable");

            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
            status = 1;

        }


        void Update()
        {
            // If the enemy and the player have health left...
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                switch (status)
                {
                    case 0:
                        UpdatePatrolState();
                        break;
                    case 1:
                        UpdateAttackState();
                        break;

                }
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }

        void UpdatePatrolState()
        {
            /*Debug.Log("Patrol");
            Debug.Log(player.position.x);
            Debug.Log(player.position.y);
            Debug.Log(inimigos.position.x);
            Debug.Log(inimigos.position.y);*/
            //Debug.Log((Mathf.Abs(player.position.x - inimigos.position.x)));
            //Debug.Log((Mathf.Abs(player.position.y - inimigos.position.y)));

            int rndIndex = UnityEngine.Random.Range(0, pointList.Length);
            destPos = pointList[rndIndex].transform.position;
            // ... set the destination of the nav mesh agent to the player.
            if ((Mathf.Abs(player.position.x - inimigos.position.x) < 5.0) && (Mathf.Abs(player.position.y - inimigos.position.y) < 5.0))
            {
                //Debug.Log("Ataque");
                status = 1;
            }
            else
            {
                nav.SetDestination(destPos);
            }

        }

        void UpdateAttackState()
        {
            /*Debug.Log("Ataque");
            Debug.Log(player.position.x);
            Debug.Log(player.position.y);
            Debug.Log(inimigos.position.x);
            Debug.Log(inimigos.position.y);*/
            nav.SetDestination(player.position);
            if ((Mathf.Abs(player.position.x - inimigos.position.x) >= 5.0) && (Mathf.Abs(player.position.y - inimigos.position.y) >= 5.0))
            {
                nav.SetDestination(player.position);
            }
            else
            {
                //Debug.Log("Patrol");
                status = 0;
            }

        }
    }

}