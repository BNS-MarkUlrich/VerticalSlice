using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaintedDialogue : MonoBehaviour
{
    private DialoogTrigger _dialoogTrigger;

    public void PokemonFainted(string pokemonName)
    {
        _dialoogTrigger.StartDialogue(pokemonName + " fainted!");  
    }
}
