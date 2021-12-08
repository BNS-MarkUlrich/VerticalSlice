using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaintedDialoog : MonoBehaviour
{
    private DialoogTrigger _dialoogTrigger;
    private WinLoseDialoog _winLoseDialoog;

    public void PlayerPokemonFainted(string pokeName)
    {
        string pokemonFaintedPlayer = pokeName + "fainted";
        _dialoogTrigger.StartDialogue(pokemonFaintedPlayer);
    }

    public void RivalPokemonFianted(string pokeName)
    {
        string pokemonFaintedRival = "Foe " + pokeName + " fainted";
        _dialoogTrigger.StartDialogue(pokemonFaintedRival);
    }

}
