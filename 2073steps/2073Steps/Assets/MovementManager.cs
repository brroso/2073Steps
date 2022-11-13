using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public Character current_character;
    public MaratonistaMovement maratonistaScript;
    public CientistaMovement cientistaScript;
    public FantasmaMovement fantasmaScript;
    public Roof cientistaRoofStart;

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
            disableCharacterScript(getCurrentActiveScript());
            enableCharacterScript(current_character);
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
            Instantiate(cientistaRoofStart);
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
            cientistaScript.resetCientista();
            cientistaScript.enabled = false;
        }
        else if (character == Character.Fantasma)
        {
            fantasmaScript.resetFantasma();
            fantasmaScript.enabled = false;
        }
    }
}
