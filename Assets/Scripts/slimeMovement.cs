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
        rbody = GetComponent<Rigidbody2D>();

        isTimerRunning = true;

        if (timer > 1f)
        {
            SlimeJump(false);
            isTimerRunning = false;
            timer = 0;
        }
    }

    void Update()
    {
        if (isTimerRunning == true)
        {
            timer += Time.deltaTime;
        }

        if (timer > 1f)
        {
            SlimeJump(true);
            isTimerRunning = false;
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTimerRunning = true;
    }    

        void SlimeJump(bool flip)
    {
        rbody.velocity = new Vector2(-moveSpeed, jumpHeight);

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
