using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CientistaMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator m_animator;
    private Sensor_Prototype m_groundSensor;
    private bool m_grounded = true;
    private bool isUpsideDown = false;
    private SpriteRenderer spriteRenderer;
    private bool c_paused = true;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        Camera cam = Camera.main;
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Prototype>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        flipCharacter();
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetFloat("AirSpeedY", 1);
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        c_paused = GameManager.gameIsPaused;
    }

    public void action()
    {
        if (!c_paused & m_grounded)
        {
            m_animator.SetTrigger("Jump");
            rb.gravityScale *= -1;
            m_animator.SetFloat("AirSpeedY", -1);
        }
    }

    public void flipCharacter()
    {
        if (!isUpsideDown & transform.position.y >= 2.5f)
        {
            transform.localScale = new Vector3(1f, -1f, 1f);
            isUpsideDown = true;
        }
        else if (isUpsideDown & transform.position.y < 2.5f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isUpsideDown = false;
        }
    }

    public void resetCientista()
    {
        rb.gravityScale = Mathf.Abs(rb.gravityScale);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Espinho" && this.enabled)
        {
            GameManager.GameOver();
        }
    }
}
