using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{

    public bool touches = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        touches = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touches = false;
    }
}
