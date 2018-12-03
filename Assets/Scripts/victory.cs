using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{

    public string levelToLoad = "level2";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("you not died");
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
