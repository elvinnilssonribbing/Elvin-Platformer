using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeMovement : MonoBehaviour
{
    public int moveSpeed = 5;
    public int jumpHeight = 15;
    private Rigidbody2D rbody;
    public bool isLeft = true;
    public bool isTimerRunning = false;
    public float timer;


    void Start()
    {
        // Här hämtas slimens Rigidbody
        rbody = GetComponent<Rigidbody2D>();
        // Timern startas
        isTimerRunning = true;

        // När timern når 1 sekund...
        if (timer > 1f)
        {
            // ...så körs SlimeJump funktionen med flip-boolen satt till false
            SlimeJump(false);
            // Timern slutar räkna
            isTimerRunning = false;
            // Timern resettas
            timer = 0;
        }
    }

    void Update()
    {
        // Om timern är tillsagd att räkna...
        if (isTimerRunning == true)
        {
            // ...så adderas den med 1 per sekund
            timer += Time.deltaTime;
        }

        // När timern når 1 sekund...
        if (timer > 1f)
        {
            // ...så körs SlimeJump funktionen med flip-boolen satt till true
            SlimeJump(true);
            // Timern slutar räkna
            isTimerRunning = false;
            // Timern resettas
            timer = 0;
        }
    }

    // När slAJmen nuddar marken...
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ...så körs timern igång och den vänder sig och hoppar, nuddar marken igen osv.
        isTimerRunning = true;
    }    

        // Här skapas funktionen för Slimens hopp, med en bool-parameter (flip) för att kunna välja om den ska vända på sig eller inte.
        void SlimeJump(bool flip)
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
            rbody.velocity = new Vector2(-moveSpeed, jumpHeight);
            //Fiendens scale ändras så att den kollar åt vänster
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Annars (om inte isLeft == true)...
        else
        {
            // ...så går fiendens hastighet positivt på x-axisen (så att den går åt höger) , men är samma på y-axisen (y var 0 ändå)...
            rbody.velocity = new Vector2(moveSpeed, jumpHeight);
            // ...och fiendens scale ändras så att den kollar åt höger
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
