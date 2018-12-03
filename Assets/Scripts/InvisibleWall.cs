using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    // När skriptet körs händer detta en gång
    void Start()
    {
        // Spelet hämtar komponenten <SpriteRenderer> som målar upp spriten (inte spriten, menar "sprajten") och stänger av den. Detta gör objektet osynligt.
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
