using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    float rotationSpeed = 1f;
    public bool goingUp = true;

    void FixedUpdate()
    {
        Debug.Log(transform.eulerAngles.z);
        if (goingUp)
        {
            if  (transform.eulerAngles.z <= 305f) 
            {
                transform.Rotate(0f, 0f, rotationSpeed);
            }
            else
            {
                goingUp = false;
            }
        }
        if (!goingUp) {
            if (transform.eulerAngles.z >= 235f)
            {
                transform.Rotate(0f, 0f, -rotationSpeed);
            }
            else
            {
                goingUp = true;
            }
        }
    }
}
