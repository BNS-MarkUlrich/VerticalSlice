using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public TurnSys currentState;

    [SerializeField] private PokeTeam rival;
    [SerializeField] private PokeTeam player;

    private BaseDialoog baseDialoog;

    private void Update()
    {
        switch (currentState)
        {
            case TurnSys.PlayerTurn:
                // Do something
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //rival._pokemons[0].GetComponent<BaseHealthScript>().TakeDamage(3);
                    RivalTurn();
                }
                // !Do something
                break;
            case TurnSys.RivalTurn:
                // Call RivalAI script
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //player._pokemons[0].GetComponent<BaseHealthScript>().TakeDamage(3);
                    PlayerTurn();
                }
                // !Call RivalAI script
                break;
            case TurnSys.DialogueState:
                // Do something

                // !Do something
                break;
            default:
                break;
        }
    }

    public void PlayerTurn()
    {
        currentState = TurnSys.PlayerTurn;
    }

    public void RivalTurn()
    {
        currentState = TurnSys.RivalTurn;
    }

    public enum TurnSys
    {
        PlayerTurn,
        RivalTurn,
        DialogueState
    }
}