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

        Text text;                      // Reference to the Text component.


        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the score.
            son = 0;
            daughter = 0;
            mother = 0;
        }

        
        void Update ()
        {
            // Set the displayed text to be the word "Kills" followed by the score value.
            //text.text = "Son: " + son + "\tDaughter: " + daughter + "\tMother: " + mother;
            text.text = string.Format("Son: {0}      Daughter: {1}      Mother: {2}", son, daughter, mother);
        }
    }
}