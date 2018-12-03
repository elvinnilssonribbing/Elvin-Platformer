using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour {

    public TextMeshProUGUI scoreText;
    public int totalScore;

    public void Update()
    {
        scoreText.text = string.Format("Score: {0}", totalScore);
    }
}
