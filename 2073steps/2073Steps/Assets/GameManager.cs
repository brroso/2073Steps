using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static float gameSpeed = 7f;
    public static float originalGameSpeed = 7f;
    public static Character current_character;
    public static Character next_character;
    public static List<Character> characters;
    public static float distance = 0;
    public static bool gameIsPaused = true;
    public AudioSource soundtrackObj;
    public static AudioSource soundtrack;

    
    public static GameObject distanceUI;
    public static bool gameJustStarted = true;
    public GameObject distanceUIObj;

    public static float minDistToSpawnObstacle = 280f;
    public static float maxDistToSpawnObstacle = 1793f;

    public static float minDistToAction = 200f;

    public GameObject fadeEffectStart;
    public GameObject fadeEffectEnd;
    public float debugDistance;

    void Awake()
    {
        distanceUI = distanceUIObj;
        soundtrack = soundtrackObj;
        Instance = this;

        distance += debugDistance;
    }

    void Start()
    {
        characters = Enum.GetValues(typeof(Character)).OfType<Character>().ToList();
        current_character = characters[0];
        characters.RemoveAt(0);
        next_character = characters[0];
        characters.RemoveAt(0);
    }

    void Update()
    {
        // Para testar o efeito de fade com Ctrl.
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            fadeEffectStart.SetActive(true);
            fadeEffectEnd.SetActive(true);
        }

        if (distance >= 2000 & distance > 0)
        {
            fadeEffectEnd.SetActive(false);
            fadeEffectStart.SetActive(true);
            fadeEffectEnd.SetActive(true);
        }

        if (distance >= 2073 & distance > 0)
        {
            NextState();
            distance = 0;
        }
    }

    public static void NextState()
    {
        UpdateCharacter();
        gameSpeed += 1f;
    }

    static void UpdateCharacter()
    {
        current_character = next_character;
        next_character = characters[0];
        characters.RemoveAt(0);

        if (characters.Count == 0)
        {
            characters = Enum.GetValues(typeof(Character)).OfType<Character>().ToList();
            Shuffle(characters);
            characters.Remove(next_character);
        }
    }

    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static void GameOver()
    {
        soundtrack.Stop();
        characters = Enum.GetValues(typeof(Character)).OfType<Character>().ToList();
        current_character = characters[0];
        characters.RemoveAt(0);
        next_character = characters[0];
        characters.RemoveAt(0);
        distance = 0;
        distanceUI.SetActive(false);
        gameIsPaused = true;
        gameJustStarted = true;
        gameSpeed = originalGameSpeed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

public enum Character
{
    Maratonista,
    Cientista,
    Fantasma
}

public enum Hazard
{
    Obstaculo,
    Espinho,
    Parede
}