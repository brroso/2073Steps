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
    }

    void Update()
    {
        current_character = GameManager.current_character;
    }
}
