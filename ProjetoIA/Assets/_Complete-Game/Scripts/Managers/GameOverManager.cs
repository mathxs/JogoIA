using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's health.

        Animator anim;                          // Reference to the animator component.

        void Awake ()
        {
            // Set up the reference.
            anim = GetComponent <Animator> ();
        }


        void Update ()
        {
            // If the player has run out of health...
            if(playerHealth.currentHealth <= 0)
            {
                // ... tell the animator the game is over.
                anim.SetTrigger ("GameOver");
            }

            if (BossHealth.currentHealth <= 0 && ScoreManager.boss)
            {
                // Tell the animator that the game has been completed
                // Wait for a couple of seconds before ending the game
                anim.SetTrigger("Win");
                StartCoroutine(Wait());

            }
        }

        public IEnumerator Wait()
        {
            //Wait a couple of seconds to let the animation playout
            yield return new WaitForSeconds(2f);
            RestartLevel();
        }

        public void RestartLevel()
        {
            // Reload the level that is currently loaded.
            SceneManager.LoadScene(0);
        }
    }
}