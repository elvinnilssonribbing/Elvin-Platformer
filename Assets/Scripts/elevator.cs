using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class elevator : MonoBehaviour {

    private Rigidbody2D rbody;
    private Vector2 currentPosition;
    private Vector2 startPosition;
    public float speed = 4;
    private float step;
    float xpos;
    float ypos;

    bool isColliding = false;

    

    void Start()
    {
        // När spelet startas så sätts två floats för hissens start-x och y positioner
        float xpos = gameObject.transform.position.x;
        float ypos = gameObject.transform.position.y;

        // De två floatsen bildar sedan en Vector2
        startPosition = new Vector2(xpos, ypos);        

        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // step finns för att kunna gångra hissens hastighet med tiden så att den åker neråt istället för att teleporteras
        float step = speed * Time.deltaTime;

        // Hissens nuvarande x och y positioner kollas varje frame
        float current_xpos = gameObject.transform.position.x;
        float current_ypos = gameObject.transform.position.y;

        // x och y positionerna sammanfogas till en Vector2
        currentPosition = new Vector2(current_xpos, current_ypos);

        // Om inte någon står på hissen...
        if (isColliding == false)
        {
            // ...så åker den tillbaks från sin nuvarande position till sin startposition med en bestämd hastighet per sekund (step)
            transform.position = Vector2.MoveTowards(currentPosition, startPosition, step);
        }
        
    }

    // Detta händer när något kolliderar med hissen
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Om det som kolliderar med hissen är spelaren...
        if (collision.collider.tag == "Player")
        {
            // ...så åker den uppåt...
            rbody.velocity = new Vector2(0, 3);
            // ...och det bestäms att någon står på hissen, så den inte dras tillbaks till sin startposition då
            isColliding = true;
        }
    }
    //Detta sker när något slutar kollidera med hissen
    void OnCollisionExit2D(Collision2D collision)
    {
        // Det bestäms att ingen står på hissen, så att den kan åka tillbaks till sin startposition igen
        isColliding = false;
    }
}
