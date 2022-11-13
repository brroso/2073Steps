using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpeed : MonoBehaviour
{
    public float gameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = GameManager.gameSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-gameSpeed * Time.deltaTime, 0f, 0f);

        if (transform.position.x <= -30)
        {
            Destroy(gameObject);
        }
    }
}
