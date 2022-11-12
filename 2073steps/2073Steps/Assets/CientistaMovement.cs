using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CientistaMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator m_animator;
    private Sensor_Prototype m_groundSensor;
    private bool m_grounded = false;
    private float flipHeight;
    private bool isUpsideDown = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Camera cam = Camera.main;
        flipHeight = 1.4f;
        m_animator = GetComponent<Animator>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Prototype>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        isUpsideDown = spriteRenderer.flipY;
        Debug.Log(flipHeight + " " + transform.position.y);
        if (Input.GetButtonDown("Jump"))
        {
            rb.gravityScale *= -1;
            flipCharacter();
        }

        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }
    }

    public void flipCharacter()
    {
        if (spriteRenderer.flipY == false)
        {
            spriteRenderer.flipY = true;
        }
        else if (spriteRenderer.flipY == true)
        {
            spriteRenderer.flipY = false;
        }
    }

    public void resetCientista()
    {
        rb.gravityScale = Mathf.Abs(rb.gravityScale);
        spriteRenderer.flipY = false;
    }
}
