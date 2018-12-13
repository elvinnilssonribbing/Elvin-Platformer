using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemies : MonoBehaviour
{

    // Den här koden ligger i en annan collisionbox som är lite under spelaren, den är en trigger för att man inte ska gå på den utan trigga ett event

    // Här skapas en bool som säger till ett annat skript om man ska studsa eller inte
    public bool shallBounce = false;

    // Detta sker när du nuddar ett objekt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Om collisionboxen nuddar ett objekt med taggen "Enemy"...
        if (collision.tag == "Enemy")
        {
            // ... så förstörs det objektet den nuddar
            Destroy(collision.gameObject);

            // man studsar uppåt i ett annat skript
            shallBounce = true;
        } 
    }

    // Om du slutar nudda...
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ...en enemy...
        if (collision.tag == "Enemy")
        {
            // ...skall du inte studsa
            shallBounce = false;
        }
    }
            
}
