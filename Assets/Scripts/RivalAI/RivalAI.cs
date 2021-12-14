using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalAI : MonoBehaviour
{
    [SerializeField] private BaseAttack[] attacks;

    // Update is called once per frame
    void Update()
    {
        // Mark Begin
        attacks = GetComponent<PokeTeam>()._pokemons[0].GetComponent<BasePokemon>().attacks;
        /*if (attacks.Length < 0)
        {
            FindObjectOfType<TurnSystem>().currentState = TurnSystem.TurnSys.WinLoseState;
            GetComponent<RivalAI>().enabled = false;
        }*/
        // Mark End
    }

    public void RivalAIBehaviour()
    {
        int attackChoice = (int)Random.Range(0, attacks.Length);

        FindObjectOfType<TurnSystem>().attackTurns.Add(attacks[attackChoice]);
    }
}