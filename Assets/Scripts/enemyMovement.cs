using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    // Här sätts variabeln för fiendens hastighet till 2
    public float movespeed = 2f;
    // Här sätts variabeln för om fienden går åt vänster eller inte till sant
    public bool isLeft = true;
    // Här ?
    private Rigidbody2D rbody;

    // Detta sker en gång när skriptet körs, i detta fallet när spelet startar eftersom fienderna finns där direkt
    void Start()
    {
        // Här ?
        rbody = GetComponent<Rigidbody2D>();
        // Här körs funktionen som finns längre ner, med flip-boolen satt till falskt eftersom fienden inte ska vända på sig när spelet startar
        Move(false);
    }

    // Här skapas en funktion med en parameter (ett värde som går att bestämma när funktionen används)
    // Denna funktionen får fienden att röra sig framåt, den ger också en möjligheten att vända på fienden när funktionen ska användas
    void Move(bool flip)
    {
        // Om flip-parametern satts till true...
        if (flip == true)
        {
            // ...så sätts variabeln för om fienden kollar åt vänster till motsatsen
            isLeft = !isLeft;
        }
        // Om fienden har blivit tillsagd att kolla åt vänster...
        if (isLeft == true)
        {
            // ...så går fiendens hastighet negativt på x-axisen (så att den går åt vänster) , men är samma på y-axisen (y var 0 ändå)
            rbody.velocity = new Vector2(-movespeed, rbody.velocity.y);
            //Fiendens scale ändras så att den kollar åt vänster
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Annars (om inte isLeft == true)...
        else
        {
            // ...så går fiendens hastighet positivt på x-axisen (så att den går åt höger) , men är samma på y-axisen (y var 0 ändå)...
            rbody.velocity = new Vector2(movespeed, rbody.velocity.y);
            // ...och fiendens scale ändras så att den kollar åt höger
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // Detta sker när objektet nuddar ett annat objekt som också använder Collider2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Om fienden kolliderar med ett objekt med taggen "enemyFlipwall"
        if (collision.tag == "enemyFlipwall")
        {
            // Fienden kommer inte bara att fortsätta röra sig framåt, utan också vända på sig (p.g.a "true")
            Move(true);
        }
    }
}
