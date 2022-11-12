using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static float gameSpeed = 7f;
    public static Character current_character;
    public static Character next_character;
    public static List<Character> characters;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        characters = Enum.GetValues(typeof(Character)).OfType<Character>().ToList();
        current_character = characters[0];
        characters.RemoveAt(0);
        next_character = characters[0];
        characters.RemoveAt(0);
    }

    public static void NextState()
    {
        UpdateCharacter();
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

        gameSpeed *= 1.2f;

        Debug.Log(current_character + " " + next_character + " " + gameSpeed);
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
}

public enum Character
{
    Maratonista,
    Cientista,
    Cowboy,
    Fantasma
}