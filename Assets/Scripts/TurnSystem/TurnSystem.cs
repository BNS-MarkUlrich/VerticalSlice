using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public TurnSys currentState = TurnSys.DialogueState;

    [SerializeField] private PokeTeam rival;
    [SerializeField] private PokeTeam player;

    private BaseDialoog baseDialoog;

    private RivalAI rivalAI;

    private void Start()
    {
        rivalAI = rival.GetComponent<RivalAI>();
    }

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
                rivalAI.Invoke("RivalAIBehaviour", 1);
                currentState = TurnSys.PlayerTurn;
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