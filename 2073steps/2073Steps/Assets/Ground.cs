using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float gameSpeed; // Velocidade em que o jogo se move.
    bool generatedGround = false;

    float cameraHeight;
    float cameraWidth;

    private void Start()
    {
        Camera cam = Camera.main;
        cameraHeight = 2f * cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;

        gameSpeed = GameManager.gameSpeed;
    }

    private void FixedUpdate()
    {
        transform.Translate(-gameSpeed * Time.deltaTime, 0f, 0f);

        if (!generatedGround)
        {
            if (transform.position.x < -(cameraWidth / 2f))
            {
                generateGround();
                generatedGround = true;
            }
        }

        if (transform.position.x < -(cameraWidth / 2))
        {
            Destroy(gameObject);
        }
    }

    void generateGround()
    {
        GameObject gro = Instantiate(gameObject);
        BoxCollider2D groCollider = gro.GetComponent<BoxCollider2D>();
        Vector2 pos;

        pos.x = cameraWidth * 1.5f;
        pos.y = 0f;

        gro.transform.position = pos;
    }
}
