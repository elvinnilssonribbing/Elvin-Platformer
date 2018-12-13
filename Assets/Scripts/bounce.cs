using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour {

    // Här hämtas scriptet för att hoppa på fiender
    public StompEnemies stomp;

    // Här hämtas spelarens rigidbody
    private Rigidbody2D rbody;

    // En bool för om timern körs skapas och sätts till falsk
    public bool isTimerRunning = false;

    // timern har ett float-värde
    public float timer;

    private void Start()
    {
        // När spelet startas hämtas rigidbodyn hos spelaren
        rbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // Om timern ska köras...
        if (isTimerRunning == true)
        {
            // ...så adderas timer floaten med 1 per sekund 
            timer += Time.deltaTime;
        }

        // Om boolen i StompEnemies-scriptet är true...
        if (stomp.shallBounce == true)
        {
            // ...så flyger spelaren uppåt...
            rbody.velocity = new Vector2(rbody.velocity.x, 10);

            // ... och timer boolen sätts till true
            isTimerRunning = true;
        }

        // När timern har nått en tiondels-sekund...
        if (timer >= 0.1f)
        {
            // ...så ska man sluta flyga uppåt, eftersom man bara flyger uppåt medans shallBounce är true...
            stomp.shallBounce = false;
            
            // ...och timern resettas och slutar köra
            isTimerRunning = false;
            timer = 0;
        }
    }
}
