using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour {

    // Här hämtas komponenten som visar text
    public TextMeshProUGUI scoreText;
   
    // Det här är dit poängen samlas för att bilda en total score
    public static int totalScore;

    // Den här inten är den som ökas när spelaren kolliderar med ett mynt
    public int changeScore;

    // Den här inten är den temporära poängen för varje level, den resettas när du dör
    public int levelScore;

    public void Update()
    {
        // Om du får en poäng...
        if (changeScore > 0)
        {
            // ...så flyttas den från changeScore till totalScore
            totalScore += 1;
            changeScore -= 1;        
        }
        // Här sätts en int som behålls mellan olika scenes
        PlayerPrefs.SetInt("Score", totalScore);
        
        // texten som TextMeshProUGUI ska visa = hur mycket poäng du har på den här nivån
        scoreText.text = string.Format("Score: {0}", levelScore);
    }

    
}
