using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    GameObject player;

    // Detta sker när scriptet körs, i detta fallet när spelet startas.
    private void Start()
    {
        // Här söker koden upp spelaren, så att den får information som behövs senare i koden
        player = GameObject.Find("player");
    }
    void Update() // Detta sker varje frame
    {
        // Här ändras kamerans x och y koordinater till dem av spelarens. Z-positionen är -10 så att ínte kameran sitter "inuti" nivån.
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
