using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    /*public GameObject roof;*/
    public float gameSpeed; // Velocidade em que o jogo se move.
    bool generatedGround = false;

    float cameraHeight;
    float cameraWidth;

    private RectTransform groundRect;
    /*private RectTransform roofRect;*/

    private void Start()
    {
        groundRect = GetComponent<RectTransform>();
        /*roofRect = GetComponent<RectTransform>();*/
        
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

        if (transform.position.x <= -(groundRect.rect.width))
            Destroy(gameObject);

        /*if (roof.transform.position.x <= -(roofRect.rect.width / 2f))
            Destroy(roof);*/
    }

    void generateGround()
    {
        GameObject gro = Instantiate(gameObject);
        BoxCollider2D groCollider = gro.GetComponent<BoxCollider2D>();
        Vector2 pos;

        pos.x = cameraWidth + (groundRect.rect.width / 2f) - (10 + gameSpeed * Time.deltaTime);
        pos.y = transform.position.y;

        gro.transform.position = pos;


        /*if (GameManager.current_character == Character.Cientista)
        {
            GameObject roofInstance = Instantiate(roof);
            BoxCollider2D roofCollider = roofInstance.GetComponent<BoxCollider2D>();
            Vector2 posR;

            posR.x = cameraWidth + (roofRect.rect.width / 2f) - (gameSpeed * Time.deltaTime);
            posR.y = 10f;

            roofInstance.transform.position = posR;
        }*/
    }
}
