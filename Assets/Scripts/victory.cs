using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
    // Detta gör så att man kan skriva in vilken nivå som ska startas på en specifik flagga i Unity
    public string levelToLoad;

    // Om flaggan nuddar...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ...spelaren...
        if (collision.tag == "Player")
        {
            // ...så laddas den scenen man skrivit in, in
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
