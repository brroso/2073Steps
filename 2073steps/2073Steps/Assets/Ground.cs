using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float gameSpeed; // Velocidade em que o jogo se move.
    bool generatedGround = false;

    float cameraHeight;
    float cameraWidth;

    private RectTransform groundRect;

    private void Start()
    {
        groundRect= GetComponent<RectTransform>();
        
        Camera cam = Camera.main;
        cameraHeight = 2f * cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;
    }

    private void FixedUpdate()
    {
        gameSpeed = GameManager.gameSpeed;
        transform.Translate(-gameSpeed * Time.deltaTime, 0f, 0f);

        if (!generatedGround)
        {
            if (transform.position.x <= -(groundRect.rect.width / 2f))
            {
                generateGround();
                generatedGround = true;
            }
        }

        if (transform.position.x <= -(groundRect.rect.width / 2f))
        {
            Destroy(gameObject);
        }
    }

    void generateGround()
    {
        GameObject gro = Instantiate(gameObject);
        BoxCollider2D groCollider = gro.GetComponent<BoxCollider2D>();
        Vector2 pos;

        pos.x = cameraWidth + (groundRect.rect.width / 2f) - (gameSpeed * Time.deltaTime);
        pos.y = transform.position.y;

        gro.transform.position = pos;
    }
}
