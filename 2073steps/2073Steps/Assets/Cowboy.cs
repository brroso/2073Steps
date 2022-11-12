using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public bool canJump = true;
    float jumpAmount = 15;
    float fallSpeed = 40;
    bool jumped = false;
    bool inAir = false;
    bool isAlive = true;

    void FixedUpdate()
    {
        if (isAlive)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") & canJump)
        {
            jumped = true;
            canJump = false;
        }
    }


    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ground")
        {
            inAir = false;
            canJump = true;
        }
    }
}
