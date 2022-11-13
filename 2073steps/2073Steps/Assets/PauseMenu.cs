using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private UIDocument uiDoc;

    void Start()
    {
        uiDoc = GetComponent<UIDocument>();
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
        else if (Input.GetKeyDown(KeyCode.Space) & GameManager.gameIsPaused)
        {
            if (GameManager.gameJustStarted)
            {
                GameManager.distanceUI.SetActive(true);
                GameManager.gameJustStarted = false;
            }
            Resume();
        }
    }
    void Resume()
    {
        uiDoc.enabled = false;
        Time.timeScale = 1.0f;
        GameManager.soundtrack.Play();
        GameManager.gameIsPaused = false;
    }

    void Pause()
    {
        uiDoc.enabled = true;
        Time.timeScale = 0f;
        GameManager.soundtrack.Pause();
        GameManager.gameIsPaused = true;
    }

}
