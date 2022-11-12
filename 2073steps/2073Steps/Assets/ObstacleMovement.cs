using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public GameObject obstacle;

    private float gameSpeed;

    float cameraHeight;
    float cameraWidth;

    public float Countdown = 10f;
    public float waitingForNextSpawn = 10f;

    float timer = 0f;

    float rTime;

    public GameObject oldObstacle;
    public GameObject newObstacle;

    // Start is called before the first frame update
    void Start()
    {

        Camera cam = Camera.main;
        cameraHeight = 2f * cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;

        //Start Invoke
        //Invoke("generateObstacle", 1f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        rTime = Random.Range(0f, 100f);

        if(rTime >= 95f)
        {
            

            if((oldObstacle.transform.position.x - transform.position.x) < -5)
            {
                GameObject newObstacle = Instantiate(obstacle);
                oldObstacle = newObstacle;
            }
            //generateObstacle();

            if (transform.position.x <= -8)
            {
                Destroy(newObstacle);
            }

            timer = 0;
        }


    }
}
