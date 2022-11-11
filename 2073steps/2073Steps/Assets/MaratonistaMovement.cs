using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaratonistaMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public bool canJump = true;
    float jumpAmount = 10;
    float fallSpeed = 40;
    float gameSpeed = 7f;
    bool jumped = false;
    bool inAir = false;
    bool isAlive = true;

    void FixedUpdate()
    {
        if (isAlive)
        {
            if (jumped == true)
            {
                playerRb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                jumped = false;
                inAir = true;
            }
            if (inAir)
            {
                Vector2 vel = playerRb.velocity;
                vel.y -= fallSpeed * Time.deltaTime;
                playerRb.velocity = vel;
            }
            transform.Translate(gameSpeed * Time.deltaTime, 0f, 0f);
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
