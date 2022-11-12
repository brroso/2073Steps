using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CientistaMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator m_animator;
    private Sensor_Prototype m_groundSensor;
    private bool m_grounded = false;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Prototype>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.gravityScale *= -1;
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
}
