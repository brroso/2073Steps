using Random = UnityEngine.Random;

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Specialized;

public class ObstacleMovement : MonoBehaviour
{
    public GameObject hazardMaratonista;
    public GameObject hazardCientista;
    public GameObject hazardFantasmaSolido;
    public GameObject hazardFantasmaFalso;

    private float gameSpeed;

    float cameraHeight;
    float cameraWidth;

    public float Countdown = 10f;
    public float waitingForNextSpawn = 10f;

    float rTime;
    float distance;

    public GameObject lastHazard;
    private GameObject newHazard;

    public int paredeRandomizer;
    public int roofRandomizer;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        cameraHeight = 2f * cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        distance = GameManager.distance;
        rTime = Random.Range(0f, 100f);

        if(rTime >= 95f & (distance > GameManager.minDistToSpawnObstacle & distance < GameManager.maxDistToSpawnObstacle))
        {
            if((lastHazard.transform.position.x - transform.position.x) < -5)
            {
                generateHazard(GameManager.current_character);
                lastHazard = newHazard;
            }
        }
    }

    void generateHazard(Character character)
    {
        if (character == Character.Maratonista)
        {
            newHazard = Instantiate(hazardMaratonista);
        }
        else if (character == Character.Fantasma)
        {
            paredeRandomizer = (int) Math.Round(Random.Range(0f, 2f));
            if (paredeRandomizer == 0)
            {
                newHazard = Instantiate(hazardFantasmaSolido);
            }
            else if (paredeRandomizer == 1)
            {
                newHazard = Instantiate(hazardFantasmaFalso);
            }
            
        }
        else if (character == Character.Cientista)
        {
            roofRandomizer = (int)Math.Round(Random.Range(0f, 2f));
            if (roofRandomizer == 0)
            {
                newHazard = Instantiate(hazardCientista);
            }
            else if (roofRandomizer == 1)
            {
                newHazard = Instantiate(hazardCientista);
                newHazard.transform.localScale = Vector3.Scale(new Vector3(1f, -1f, 1f), newHazard.transform.localScale);
                newHazard.transform.position = new Vector3(newHazard.transform.position.x, 5.9f, newHazard.transform.position.z);
            }
        }
    }
}
