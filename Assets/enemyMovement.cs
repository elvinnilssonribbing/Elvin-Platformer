using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    public float movespeed = 2f;
    public bool isLeft = true;
    public Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        Move(false);
    }

    void Move(bool flip)
    {
        if (flip == true)
        {
            isLeft = !isLeft;
        }

        if (isLeft == true)
        {
                rbody.velocity = new Vector2(-movespeed, rbody.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            rbody.velocity = new Vector2(movespeed, rbody.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Invi-wall")
        {
            Move(true);
        }
    }

}
