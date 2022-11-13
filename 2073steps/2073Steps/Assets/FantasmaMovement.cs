using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FantasmaMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public bool isTangible = true;
    private Sensor_Prototype m_groundSensor;
    private bool m_grounded = true;
    float fallSpeed = 40;
    private Animator m_animator;
    private bool f_paused = true;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Prototype>();
    }

    void FixedUpdate()
    {
        if (!m_grounded)
        {
            Vector2 vel = playerRb.velocity;
            vel.y -= fallSpeed * Time.deltaTime;
            playerRb.velocity = vel;
        }
    }
    void Update()
    {
        if (!f_paused & Input.GetButtonDown("Jump"))
        {
            m_animator.SetTrigger("Jump");
            m_animator.SetFloat("AirSpeedY", -1);
            if (isTangible)
            {
                isTangible = false;
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = new Color(0f, (196f/255f), 1.0f, 0.5f);
                }
            }
            else
            {
                isTangible = true;
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1f);
                }
            }
        }
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

        f_paused = GameManager.gameIsPaused;
    }

    public void resetFantasma()
    {
        isTangible = true;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ParedeSolida" & isTangible)
        {
            GameManager.GameOver();
        }
        else if (collision.gameObject.tag == "ParedeFalsa" & !isTangible)
        {
            GameManager.GameOver();
        }
    }
}
