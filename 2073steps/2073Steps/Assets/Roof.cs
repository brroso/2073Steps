using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Roof : MonoBehaviour
{
    public GameObject roofPrefab;
    public float gameSpeed; // Velocidade em que o jogo se move.
    public bool spawn_point = false;

    private GameObject roof;
    private RectTransform roofRect;
    private float cameraHeight;
    private float cameraWidth;

    private void Start()
    {
        Camera cam = Camera.main;
        cameraHeight = 2f * cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;

        Debug.Log(cameraWidth);

        if (spawn_point)
            generateRoof(roofPrefab);
        else
        {
            roofRect = GetComponent<RectTransform>();
        }
    }

    private void FixedUpdate()
    {
        if (!spawn_point)
        {
            gameSpeed = GameManager.gameSpeed;
            transform.Translate(-gameSpeed * Time.deltaTime, 0f, 0f);

            if (GameManager.current_character == Character.Cientista)
            {
                if (transform.position.x <= -(roofRect.rect.width / 2f))
                    generateRoof(gameObject);
            }

            if (transform.position.x <= -(roofRect.rect.width / 2f))
                Destroy(gameObject);
        }
    }

    void generateRoof(GameObject obj)
    {       
        if (spawn_point)
        {
            roof = Instantiate(obj);
            BoxCollider2D roofCollider = roof.GetComponent<BoxCollider2D>();
            Vector2 pos;

            pos.x = (2f * cameraWidth) - (gameSpeed * Time.deltaTime);
            pos.y = transform.position.y;

            roof.transform.position = pos;

            GameObject roof2 = Instantiate(obj);
            BoxCollider2D roofCollider2 = roof2.GetComponent<BoxCollider2D>();
            Vector2 pos2;

            pos2.x = (3f * cameraWidth) - (gameSpeed * Time.deltaTime);
            pos2.y = transform.position.y;

            roof2.transform.position = pos2;
        }
        else
        {
            roof = Instantiate(obj);
            BoxCollider2D roofCollider = roof.GetComponent<BoxCollider2D>();
            Vector2 pos;

            pos.x = cameraWidth + (roofRect.rect.width / 2) - (gameSpeed * Time.deltaTime);
            pos.y = transform.position.y;

            roof.transform.position = pos;
        }
    }
}
