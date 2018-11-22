using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class playerMovement : MonoBehaviour
{    
    [Range(0, 20f)] public float moveSpeed = 10f;
    public float jumpHeight = 7f;
    private Rigidbody2D rbody;
    public groundcheck groundcheck;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        groundcheck = gameObject.GetComponentInChildren<groundcheck>();
    }

    // Update is called once per frame
    void Update()
    { 
        
        rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
             if (groundcheck.touches == true)

             {
                rbody.velocity = new Vector2(rbody.velocity.x, jumpHeight);
             }
        }
        
    }
}
