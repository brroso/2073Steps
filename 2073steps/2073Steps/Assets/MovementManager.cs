using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public Character current_character;
    public MaratonistaMovement maratonistaScript;
    public CientistaMovement cientistaScript;
    public FantasmaMovement fantasmaScript;

    void Start()
    {
        current_character = GameManager.current_character;
        enableCharacterScript(current_character);
    }

    void Update()
    {
        
        current_character = GameManager.current_character;
        if (getCurrentActiveScript() != current_character)
        {
            enableCharacterScript(current_character);
            disableCharacterScript(getCurrentActiveScript());
        }
    }

    Character getCurrentActiveScript()
    {
        if (maratonistaScript.enabled)
        {
            return Character.Maratonista;
        }
        else if (cientistaScript.enabled)
        {
            return Character.Cientista;
        }    
        else
        {
            return Character.Fantasma;
        }
    }

    void enableCharacterScript(Character character)
    {
        if (character == Character.Maratonista)
        {
            maratonistaScript.enabled = true;
        }
        else if (character == Character.Cientista)
        {
            cientistaScript.enabled = true;
        }
        else
         {
            fantasmaScript.enabled = true;
        }

    }

    void disableCharacterScript(Character character)
    {
        if (character == Character.Maratonista)
        {
            maratonistaScript.enabled = false;
        }
        else if (character == Character.Cientista)
        {
            cientistaScript.enabled = false;
        }
        else
        {
            fantasmaScript.enabled = false;
        }
    }
}
