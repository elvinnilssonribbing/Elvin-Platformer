using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    // Här sätts variabeln för om objektet (spelaren) nuddar marken till 0
    public int touches = 0;

    // När objektet (spelaren) nuddar ett annat objekt med Collider2D...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //...och om objektet inte är en fiende...
        if (collision.gameObject.tag != "Enemy")
        {
            // ...så adderas touches-variabeln med 1
            touches++;
        } 
    }

    // När objektet (spelaren) slutar att nudda ett annat objekt med Collider2D...
    private void OnTriggerExit2D(Collider2D collision)
    {
        //...och om objektet inte är en fiende...
        if (collision.gameObject.tag != "Enemy")
        {
            // ...så subtraheras touches-variabeln med 1
            touches--;
        }
    }
}
