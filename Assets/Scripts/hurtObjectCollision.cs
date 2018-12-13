using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hurtObjectCollision : MonoBehaviour
{
    // Detta sker när objekten som har detta skript nuddar ett annat objekt med Collider 2D  p.s: nuddar = att hitboxen delar koordinater med ett annat objekts hitbox
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Om objektet kolliderar med ett annat objekt som har taggen "Player"...
        if (collision.gameObject.tag == "Player")
        {
            // ...så hämtar spelet den aktiva scenen...
            Scene active = SceneManager.GetActiveScene();
            //...och laddar in den igen (spelet börjar om när du dör helt enkelt)
            SceneManager.LoadScene(active.name);
        }
    }
}

