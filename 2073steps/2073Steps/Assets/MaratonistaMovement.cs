using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaratonistaMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    float jumpAmount = 15;
    float fallSpeed = 40;
    bool jumped = false;
    private Animator m_animator;
    private Sensor_Prototype m_groundSensor;
    private bool m_grounded = false;
    private bool m_paused = true;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Prototype>();
    }

    void FixedUpdate()
    {
        if (jumped == true)
        {
            playerRb.AddForce(Vector2.up * jumpAmount * (1 + (GameManager.gameSpeed / GameManager.originalGameSpeed) * 0.2f), ForceMode2D.Impulse);
            jumped = false;
        }
        if (!m_grounded)
        {
            Vector2 vel = playerRb.velocity;
            vel.y -= fallSpeed * Time.deltaTime * (GameManager.gameSpeed / GameManager.originalGameSpeed);
            playerRb.velocity = vel;
        }
    }

    // Update is called once per frame
    void Update()
    {
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

        // -- Handle Animations --
        //Jump
        

        m_paused = GameManager.gameIsPaused;
    }

    public void action()
    {
        if (!m_paused && m_grounded)
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            jumped = true;
            m_groundSensor.Disable(0.2f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && this.enabled)
        {
            GameManager.GameOver();
        }
    }
}
