using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxSpeed;
    public int sortingOrder = 0;
    private SpriteRenderer sprite;
    private float cameraHeight;
    private float cameraWidth;

    private RectTransform imageRect;

    bool generatedBG = false;

    void Start()
    {
        imageRect = GetComponent<RectTransform>();

        Camera cam = Camera.main;
        cameraHeight = 2f * cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;

        sprite = GetComponent<SpriteRenderer>();

        if (sprite)
        {
            sprite.sortingOrder = sortingOrder;
            parallaxSpeed = sortingOrder * GameManager.gameSpeed * 0.1f;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(-parallaxSpeed * Time.deltaTime, 0f, 0f);
        // Debug.Log(transform.position);

        if (!generatedBG)
        {
            if (transform.position.x < -(imageRect.rect.width / 2f))
            {
                generateBG();
                generatedBG = true;
            }
        }

        if (transform.position.x < -imageRect.rect.width)
        {
            Destroy(gameObject);
        }
    }

    void generateBG()
    {
        GameObject bg = Instantiate(gameObject);
        Vector2 pos;

        pos.x = transform.position.x + (2f * imageRect.rect.width) + cameraWidth;
        pos.y = transform.position.y;

        bg.transform.position = pos;
    }


    /*private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }*/
}
