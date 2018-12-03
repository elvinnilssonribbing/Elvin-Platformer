using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class playerMovement : MonoBehaviour
{
    // Spelarens hastighet "moveSpeed" sätts till 10, men range-grejen och att den är public
    // gör att vi kan dra i en slider både innan och medans vi spelar spelet för att höja och sänka spelarens hastighet till allt mellan 0 och 20.
    [Range(0, 20f)] public float moveSpeed = 10f;

    // Här sätts variabeln för hur högt (eller egentligen hur snabbt) spelaren ska kunna hoppa
    public float jumpHeight = 7f;

    // Här ?
    private Rigidbody2D rbody;

    // Här ?
    public groundcheck groundcheck;

    // värdet för hur många extra hopp du får göra i luften
    public int jumpValue = 1;

    // Här ?
    bool facingleft = false;

    // Detta sker en gång när skriptet körs
    void Start()
    {
        // Här ?
        rbody = GetComponent<Rigidbody2D>();
        
        // Här ?
        groundcheck = gameObject.GetComponentInChildren<groundcheck>();
    }

    // Detta sker varje frame
    void Update()
    {
        // Här körs funktionen "Movement()"
        Movement();

        // Här körs funktionen "Jumping()"
        Jumping();
    }

    // Här skapas funktionen "Jumping()"
    private void Jumping()
    {
        // Om du nuddar marken eller om du har ett dubbelhopp (jumpValue) kvar...
        if (groundcheck.touches > 0 || jumpValue > 0)
        {
            // ...och du trycker på space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ... så blir spelarens hastiget samma i x-axisen men värdet i y-axisen blir istället värdet av "jumpHeight"
                // vilket får spelaren att behålla sitt horisontella momentum men också hoppa uppåt. Detta gör det möjligt med hopp i olika riktningar än rakt upp.
                rbody.velocity = new Vector2(rbody.velocity.x, jumpHeight);
                // Värdet för spelarens dubbelhopp minskas med 1 när du hoppar, men längre ner i koden står det att jumpValue adderas med 1
                // om spelaren nuddar marken, vilket gör att ingen jumpValue försvinner om du hoppar från marken utan bara om du hoppar i luften.
                jumpValue -= 1;
            }
        }

        // (som sagt ovan) Om spelaren nuddar marken...
        if (groundcheck.touches > 0)
        {
            // ...adderas jumpValue med 1
            jumpValue += 1;
        }

        // Om jumpValue är under 0...
        if (jumpValue < 0)
        {
            // ...så blir den 0, inte lägre            
            jumpValue = 0;
        }

        if (jumpValue > 1)
        {
            // ... så blir den 1, inte högre
            // Detta förhindrar möjligheten att "stacka upp" på dubbelhopp genom att inte använda dem för att sedan använda flera åt gången.
            jumpValue = 1;
        }
    }

    // Här skapas funktionen "Movement()"
    private void Movement()
    {
        // Spelarens nya hastighet bestäms av värdet av Inputen "Horizontal" (-1 till 1) (Inputen "Horizontal är inbyggt i Unity och knapparna 
        // som används går att justera i Input menyn) gånger spelarens bestämda hastighet. Y-axisen stannar densamma.
        rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rbody.velocity.y);


        // (Här nedan används inte  Unity's input eftersom jag inte visste hur. Jag valde att istället använda de två olika kontrollmöjligheterna)

        // Om A eller vänsterpil trycks ner...
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // ...så blir spelarens scale vänd åt vänster
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Om D eller högerpil trycks ner...
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // ...så blir spelarens scale vänd åt höger
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
