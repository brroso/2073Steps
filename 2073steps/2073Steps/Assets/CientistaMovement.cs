using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CientistaMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.gravityScale *= -1;
        }
    }
}
