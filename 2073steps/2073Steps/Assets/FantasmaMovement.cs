using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaMovement : MonoBehaviour
{
    public bool isTangible = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isTangible)
            {
                isTangible = false;
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
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
    }
}
