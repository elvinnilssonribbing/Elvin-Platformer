using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int score = 1;

    // Detta sker när objektet nuddar ett annat objekt som också använder Collider2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Om objektet nuddar ett objekt med taggen "Player"
        if (collision.tag == "Player")
        {
            //Skapa en temporär variabel "controller" och sätt den till
            //resultatet av sökningen efter objektet med taggen "GameController".
            GameObject controller = GameObject.FindWithTag("GameController");
            if (controller != null)
            {
                //Skapa en temporär variabel "tracker" och sätt den till
                //resultatet av sökningen efter komponenten "ScoreTracker".
                ScoreTracker tracker = controller.GetComponent<ScoreTracker>();
                if (tracker != null)
                {
                    tracker.totalScore += score;
                }
                else
                {
                    Debug.LogError("ScoreTracker saknas på GameController.");
                }
            }
            else
            {
                Debug.LogError("GameContoller finns inte.");
            }

            Destroy(gameObject);
        }
    }
}
