using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int son;        // The number of sons that died.
        public static int daughter;     // The number of daughters that died.
        public static int mother;       // The number of times the mother died.
        public static bool boss;
        public static int life;
        
        Text text;                      // Reference to the Text component.
        public Slider bossSlider;       // Reference to the Boss slider and to control it's health
        public Image img;               // Reference to the skull image


        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the score.
            // Disable the boss UIs so they won't appear
            son = 0;
            daughter = 0;
            mother = 0;
            boss = false;
            bossSlider.gameObject.SetActive(false);
            img.enabled = false;
        }

        
        void Update ()
        {
            // Set the displayed text to be the word "Kills" followed by the score value.
            //text.text = "Son: " + son + "\tDaughter: " + daughter + "\tMother: " + mother;
            if(son + daughter + mother >= 25)
            {
                boss = true;
            }
            if (boss)
            {
                // When boss is spawned, eliminate current score count and bring up boss health bar
                text.enabled = false;
                img.enabled = true;
                bossSlider.gameObject.SetActive(true);
                bossSlider.value = BossHealth.currentHealth;
            }
            else
            {
                // Score to count the number of times the relatives were killed.
                text.text = string.Format("Son: {0}      Daughter: {1}      Mother: {2}", son, daughter, mother);
            }
        }
    }
}