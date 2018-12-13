using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int score = 1;

    // Detta sker när objektet nuddar ett annat objekt som också använder Collider2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Om objektet nuddar ett objekt med taggen "Player"...
        if (collision.tag == "Player")
        {
            // ...så skapas en temporär variabel "controller" och sätts till
            // resultatet av sökningen efter objektet med taggen "GameController"
            GameObject controller = GameObject.FindWithTag("GameController");

            // ... och om kontrollern finns...
            if (controller != null)
            {
                // ...så skapas en temporär variabel, "tracker" och sätts till
                // resultatet av sökningen efter komponenten "ScoreTracker"
                ScoreTracker tracker = controller.GetComponent<ScoreTracker>();

                // ...och om trackern finns
                if (tracker != null)
                {
                    // så ökas totalscoren med 1
                    tracker.changeScore += score;

                    // och levelscoren med 1
                    tracker.levelScore += 1;
                }
                // Annars...
                else
                {
                    // ...blir det fel
                    Debug.LogError("ScoreTracker saknas på GameController.");
                }
            }
            // Annars...
            else
            {
                // ...blir det 2 fel
                Debug.LogError("GameController finns inte.");
            }
            // Myntet förstörs när spelaren nuddar det
            Destroy(gameObject);
        }
    }
}
