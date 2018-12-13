using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    // temporär variabel för den totala poängen
    public int myScore;

    // komponenten som visar texten hämtas
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // myScore sätts till den totala poängen
        myScore = PlayerPrefs.GetInt("Score");

        // Den här visar din totala poäng i Victory-skärmen
        scoreText.text = string.Format("Final Score: {0}", myScore);
    }
}
