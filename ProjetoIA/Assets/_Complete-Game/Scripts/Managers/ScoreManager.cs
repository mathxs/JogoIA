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
        public Slider bossSlider;
        public Image img;


        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the score.
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
            if(son + daughter + mother >= 1)
            {
                boss = true;
            }
            if (boss)
            {
                Debug.Log(BossHealth.currentHealth);
                //text.text = string.Format("Life: {0}%", (BossHealth.currentHealth/ 1000f) * 100f);
                text.enabled = false;
                img.enabled = true;
                bossSlider.gameObject.SetActive(true);
                bossSlider.value = BossHealth.currentHealth;
            }
            else
            {
                text.text = string.Format("Son: {0}      Daughter: {1}      Mother: {2}", son, daughter, mother);
            }
        }
    }
}